using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCharacter : MonoBehaviour
{
    public static MainCharacter instance;

    [SerializeField]
    Rigidbody2D Character;

    [SerializeField]
    Collider2D cCollider;

    [SerializeField]
    private float runSpeed;

    [SerializeField]
    private bool yAct = true;
    public bool hitted = false;

    [SerializeField]
    private Animator animationController;
    public CheackPoint cheackPoint;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
        gameObject.tag = Constants.PlayeTag;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hitted)
        {
            HandleMovement();

            HandleGravity();
        }
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal != 0)
        {
            Vector3 movement = new(runSpeed * horizontal * Time.deltaTime, 0, 0);
            Character.position = transform.position + movement;

            Character.transform.localScale = new Vector3(Mathf.Sign(horizontal), 1, 1);
        }

        animationController.SetFloat("SPEED", Mathf.Abs(horizontal * runSpeed));
    }

    void HandleGravity()
    {
        if (yAct && Input.GetKeyDown(KeyCode.Space))
        {
            animationController.SetBool("JUMP", true);

            Character.gravityScale = -Character.gravityScale;

            Character.transform.Rotate(180, 0, 0);

            yAct = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        yAct = true;
        animationController.SetBool("JUMP", false);
    }

    public void HandleDead()
    {
        hitted = true;
        animationController.SetBool("HIT", true);
    }

    public void Spawn()
    {
        //reset rigidBody
        Character.gravityScale = math.abs(Character.gravityScale);
        transform.rotation = Quaternion.identity;
        Character.position = new(cheackPoint.x, cheackPoint.y);
        Character.velocity = new(0, 0);

        animationController.SetBool("HIT", false);
        hitted = false;
        SceneManager.LoadScene(cheackPoint.level);
    }

    public void SetCheackPoint(float x, float y, string scene)
    {
        cheackPoint = new(x, y, scene);
    }
}

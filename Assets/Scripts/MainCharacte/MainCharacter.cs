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
    private float runSpeed,
        distance = 1;

    [SerializeField]
    private bool yAct = true;
    public bool hitted = false;

    [SerializeField]
    private Animator animationController;
    public CheackPoint cheackPoint;

    RaycastHit2D hit;

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
     void FixedUpdate()
    {

        if (!hitted && !Menu.isPaused)
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
            Vector3 movement = new(runSpeed * horizontal, 0, 0);
            Character.position = transform.position + movement;

            Character.transform.localScale = new Vector3(Mathf.Sign(horizontal), 1, 1);
        }

        animationController.SetFloat("SPEED", Mathf.Abs(horizontal * runSpeed));
    }

    void HandleGravity()
    {
        hit = Physics2D.Raycast(transform.position, -transform.up, distance);
        Debug.DrawLine(transform.position, transform.position - transform.up * distance, Color.red);

        if (hit.collider != null && hit.collider.gameObject.CompareTag("Ground"))
        {
            yAct = true;
        }
        else
        {
            yAct = false;
        }

        if (yAct && Input.GetKeyDown(KeyCode.Space))
        {
            Character.gravityScale = -Character.gravityScale;

            Character.transform.Rotate(180, 0, 0);
        }

        animationController.SetBool("JUMP", !yAct);
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

    public static void DestroySingleton()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
            instance = null;
        }
    }
}

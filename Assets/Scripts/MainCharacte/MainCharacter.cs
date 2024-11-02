using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    public static MainCharacter instance;

    [SerializeField] Rigidbody2D Character;
    [SerializeField] Collider2D cCollider;

    [SerializeField] private float runSpeed, ySpeed;

    [SerializeField] private bool yAct = true;
    public bool hitted = false;

    [SerializeField] private Animator animationController;

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
        cheackPoint = new(6, 1, "LEVEL_2");
    }

    // Update is called once per frame
    void Update()
    {
        HandleDead(hitted);

        HandleMovement();

        HandleGravity();


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

        animationController.SetFloat("Speed", Mathf.Abs(horizontal * runSpeed));
    }
    void HandleGravity()
    {
        if (yAct && Input.GetKeyDown(KeyCode.Space))
        {
            animationController.SetBool("JUMP", true);

            Character.gravityScale = -Character.gravityScale;

            Character.transform.Rotate(180, 0, 0);

            ySpeed = -ySpeed;

            yAct = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        yAct = true;
        animationController.SetBool("JUMP", false);
    }

    void HandleDead(bool control)
    {
        cCollider.isTrigger=control;
        animationController.SetBool("HIT", control);
    }

    public void Spawn()
    {
        cCollider.isTrigger=false;
        Character.position = new(cheackPoint.x, cheackPoint.y);
    }
}

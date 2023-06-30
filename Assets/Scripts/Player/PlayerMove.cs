using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{

    private Animator animator;
    public InputActionAsset playerActions;
    private InputActionMap player;
    private InputAction move;
    private InputAction jump;
    private InputAction slide;
    public float moveValue;
    public bool jumpPressed;
    public bool slidePressed;
    public float leftRightSpeed = 4f;
    public float acceleration = 5f;
    static public bool canMove { get; set; }
    private Rigidbody rb;
    private bool isGrounded = true;
    private bool noSlide = true;
    private bool canJump = true;

    void Awake()
    {
        player = playerActions.FindActionMap("player");
        move = player.FindAction("Movement");
        jump = player.FindAction("Jump");
        slide = player.FindAction("Slide");

        move.performed += ctx => moveValue = ctx.ReadValue<float>();
        move.canceled += ctx => moveValue = 0;

        jump.performed += ctx => jumpPressed = true;
        jump.canceled += ctx => jumpPressed = false;
        slide.performed += ctx => slidePressed = true;
        slide.canceled += ctx => slidePressed = false;
    }

    void Start()
    {
        canMove = false;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        move.Enable();
        jump.Enable();
        slide.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        jump.Disable();
        slide.Disable();
    }


    void Update()
    {

        if (transform.position.x > 3)
        {
            transform.position = new Vector3(3, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -3)
        {
            transform.position = new Vector3(-3, transform.position.y, transform.position.z);
        }
    }

    private void FixedUpdate()
    {

        if (canMove && rb.position.x >= -3 && rb.position.x <= 3)
        {
            
            animator.SetBool("isRunning", true);
            transform.Translate(Vector3.right * moveValue * leftRightSpeed * Time.deltaTime);
            
        }

        if (canMove && jumpPressed)
        {
            Jump();
        }
        if (canMove && slidePressed && isGrounded && noSlide)
        {
            StartCoroutine(Slide());
        }

    }

    /** private void Slide()
     {
         if (slidePressed && isGrounded && noSlide)
         {
             noSlide = false;
             Debug.Log("me agacho");
             animator.SetTrigger("Slide");
             noSlide = true;
         }
     }**/

    IEnumerator Slide()
    {
        noSlide = false;
        Debug.Log("me agacho");
        animator.SetTrigger("Slide");
        yield return new WaitForSeconds(1f);
        noSlide = true;
    }

    private void Jump()
    {
        if(isGrounded){
        animator.SetTrigger("jump");
        rb.AddForce(Vector3.up * acceleration, ForceMode.Impulse);
        canJump = true;
        isGrounded = false;
        }

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("estoy en el suelo");

        }
    }
}


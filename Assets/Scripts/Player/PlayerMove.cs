using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
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
    static public bool canMove = false;
    private Rigidbody rb;
    private bool isGrounded = true;

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
        Vector3 velocity = rb.velocity;
        if (canMove == true)
        {
            if (rb.position.x >= LevelBoundary.leftSide && rb.position.x <= LevelBoundary.rightSide)
            {
                velocity.x = moveValue * leftRightSpeed;
                rb.velocity = velocity;

            }

            if (transform.position.x > LevelBoundary.rightSide)
            {
                transform.position = new Vector3(LevelBoundary.rightSide, transform.position.y, transform.position.z);
            }
            if (transform.position.x < LevelBoundary.leftSide)
            {
                transform.position = new Vector3(LevelBoundary.leftSide, transform.position.y, transform.position.z);
            }

            if (jumpPressed && isGrounded)
            {
                rb.AddForce(Vector3.up * acceleration, ForceMode.Impulse);
                isGrounded = false;
            }

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

    }

}

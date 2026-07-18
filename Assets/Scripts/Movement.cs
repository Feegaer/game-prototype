using Assets.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform playerBody;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Animator animator;

    [Header("Move Settings")]
    [SerializeField] private float baseSpeed = 4.3f;
    [SerializeField] private float sprintMultiplier  = 0.7f;
    [SerializeField] private float crouchMultiplier  = 0.25f;
    [SerializeField] private float animationDamping = 0.12f;

    [Header("Ground Settings")]
    [SerializeField] private float groundDistance = 0.3f;
    [SerializeField] private float jumpForce = 4f;

    [SerializeField] private LayerMask groundLayer;

    private Vector2 input;
    private bool isGrounded;
    private bool isCrouching;

    private void Start()
    {
        if(animator == null) animator = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckGround();
        UpdateAnimator();
    }
    private void FixedUpdate()
    {
        Move();
    }
    // ==============================================================
    // ==============================================================
    // ==============================================================
    public void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
    }
    public void OnSprint(InputValue value)
    {
        if (isCrouching) return;
        if (value.isPressed)
        {
            sprintMultiplier  = 2.5f;

            Debug.Log("Sprint button was pressed.");
        }
        else
        {
            sprintMultiplier  = 1f;
            Debug.Log("Sprint button was released.");
        }
    }
    public void OnJump(InputValue value)
    {
        if(value.isPressed) Debug.Log("Jump button was pressed.");
        if (!value.isPressed) return;
        if (!isGrounded) return;

        rb.linearVelocity = new Vector3(
            rb.linearVelocity.x,
            jumpForce,
            rb.linearVelocity.z
        );
    }

    public void OnCrouch(InputValue value)
    {
        if(value.isPressed) Debug.Log("Crouch button was pressed.");
        if (!value.isPressed) return;
        isCrouching = !isCrouching;
    }

    // ==============================================================
    // ==============================================================
    // ==============================================================
    private void Move()
    {
        float movementMultiplier = isCrouching ? crouchMultiplier : 1f;
        Vector3 forward = playerBody.forward;
        Vector3 right = playerBody.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 direction =
            forward * input.y +
            right * input.x;

        float targetSpeed =
            baseSpeed * sprintMultiplier * movementMultiplier;

        Vector3 targetVelocity =
            direction * targetSpeed;

        targetVelocity.y =
            rb.linearVelocity.y;

        rb.linearVelocity = Vector3.Lerp(
            rb.linearVelocity,
            targetVelocity,
            10f * Time.fixedDeltaTime
        );
    }

    private void CheckGround()
    {
        isGrounded = Physics.CheckSphere(
            groundCheck.position, 
            groundDistance, 
            groundLayer
        );
    }

    private void OnDrawGizmosSelected() // Draws an yellow sphere around the selected game object, just for debugging purposes
    {
        if (groundCheck == null) return;

        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(
            groundCheck.position,
            groundDistance
        );
    }

    private void UpdateAnimator()
    {

        Vector3 horizontalVelocity = new Vector3(
            rb.linearVelocity.x, 
            0f, 
            rb.linearVelocity.z
        );

        float speed = horizontalVelocity.magnitude;

        animator.SetFloat("Speed", speed, animationDamping, Time.deltaTime);
        animator.SetBool("Grounded", isGrounded);
        animator.SetBool("IsCrouching", isCrouching);
        // Debug.Log(speed);
    }
}
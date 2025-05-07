using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;

    public float walkSpeed = 12f; 
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 _velocity;

    private Vector3 _lastPosition = new Vector3(0f, 0f, 0f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleJump();
    }

    private void HandleMovement()
    {
        // Collect input
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // Calculate move direction
        Vector3 moveDirection = transform.right * xInput + transform.forward * zInput;

        //Apply movement to player
        _controller.Move(moveDirection * walkSpeed * Time.deltaTime);

        // Set last position
        _lastPosition = gameObject.transform.position;
    }

    private void HandleJump()
    {
        // Reset vertical velocity when grounded
        if(IsGrounded() && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        // Check for jump Input
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            // Calculate new vertical velocity when jumping
            _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //Apply vertical velocity to player
        _controller.Move(_velocity * Time.deltaTime);

        // Apply gravity to player
        _velocity.y += gravity * Time.deltaTime;
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    } 

    private bool isMoving()
    {
        return _lastPosition != gameObject.transform.position && IsGrounded();
    }
}

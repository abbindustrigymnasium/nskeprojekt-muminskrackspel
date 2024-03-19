using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    private Vector3 moveDirection;
    private Vector3 velocity;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;

    [SerializeField] private float jumpHeight;

    private CharacterController controller;
    private Animator anim;

    public float health;

    public float Speed;
    public Transform Cam;
    public Transform Player; 

    public GameObject crosshair;

    public bool moving;
    public static bool canMove = true;

    public float minValue = 0f;
    public float maxValue = 1f;
    public float switchInterval = 5f; // Interval in seconds to switch animations

    private float timeSinceLastSwitch = 0f;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Camera();

        if (moving == false)
        {
            // Update timer
            timeSinceLastSwitch += Time.deltaTime;

            // Check if it's time to switch animations
            if (timeSinceLastSwitch >= switchInterval)
            {
                // Generate random float value
                float randomValue = Random.Range(minValue, maxValue);
                float roundedValue = Mathf.Round(randomValue * 2) / 2;
                // Update the float parameter in the animator
                anim.SetFloat("idleFloat", roundedValue, 0.1f, Time.deltaTime);

                // Reset timer
                timeSinceLastSwitch = 0f;
            }
        }

    }

    private void Move()
    {
        if (canMove)
        {
            isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float moveZ = Input.GetAxis("Vertical");
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);

            if (isGrounded)
            {
                if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
                {
                    Walk();
                }
                else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
                {
                    Run();
                }
                else if (moveDirection == Vector3.zero)
                {
                    Idle();
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Jump();

                }
                //anim.SetBool("Jump", false);
                moveDirection *= moveSpeed;
            }
            else
            {
                //anim.SetBool("Jump", true);
                //anim.SetFloat("JumpTime", 1, 0.1f, Time.deltaTime);
                moveDirection *= moveSpeed;
            }
            controller.Move(moveDirection * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }

    private void Idle()
    {
        anim.SetFloat("moveFloat", 0f, 0.1f, Time.deltaTime);
        anim.SetFloat("idleFloat", 0.5f, 0.1f, Time.deltaTime);
        moving = false;
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("moveFloat", 0.5f, 0.1f, Time.deltaTime);
        moving = true;
    }

    private void Run()
    {
        moveSpeed = runSpeed;
        anim.SetFloat("moveFloat", 1, 0.1f, Time.deltaTime);
        moving = true;
    }

    private void Jump()
    {
        //anim.SetFloat("JumpTime", 0.5f, 0.1f, Time.deltaTime);
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        moving = false;
    }

    void Camera()
    {
        float Horizontal = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        float Vertical = Input.GetAxis("Vertical") * Speed * Time.deltaTime;

        Vector3 Movement = Cam.transform.right * Horizontal + Cam.transform.forward * Vertical;
        Movement.y = 0f;

        controller.Move(Movement);

        if (Movement.magnitude != 0f)
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Cam.GetComponent<CameraScript>().sensivity * Time.deltaTime);

            Quaternion CamRotation = Cam.rotation;
            CamRotation.x = 0f;
            CamRotation.z = 0f;

            transform.rotation = Quaternion.Lerp(transform.rotation, CamRotation, 0.1f);
        }
    }
}

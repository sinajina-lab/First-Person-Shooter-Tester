using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float walkSpeed = 10f;
    [SerializeField] float runSpeed = 30f;
    [SerializeField] float jumpHeight = 3f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float groundDistance = 0.2f;
    //Check how much vertical motion chanhes
    Vector3 velocity;
    bool isGrounded;

    [SerializeField] float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;

    [SerializeField] float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float currentSpeed;

    Animator animator;
    Transform cameraT;

    private void Start()
    {
        animator = GetComponent<Animator>();
        cameraT = Camera.main.transform;
    }
    private void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 inputDir = input.normalized;

        if (inputDir != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
        }

        bool running = Input.GetKey(KeyCode.LeftShift);

        float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;

        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);

        float animationSpeedPercent = ((running) ? 1 : .5f) * inputDir.magnitude;
        animator.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);

    }
     
}

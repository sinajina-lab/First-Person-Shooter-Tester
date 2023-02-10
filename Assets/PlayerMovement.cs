using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float walkSpeed;
    [SerializeField] float sprint;
    [SerializeField] float jumpHeight;

    [SerializeField]float horizontaInput;
    [SerializeField]float verticalInput;

    Rigidbody rb;

    private void Awake()
    {
       rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        horizontaInput = Input.GetAxis("Horizontal") * walkSpeed;

        verticalInput = Input.GetAxis("Vertical") * walkSpeed;
    }
    private void FixedUpdate()
    {
        //rb.velocity = Vector3.right * horizontaInput;
        //rb.velocity = Vector3.forward * verticalInput;

        rb.velocity = new Vector3(horizontaInput, 0, verticalInput);
    }
}

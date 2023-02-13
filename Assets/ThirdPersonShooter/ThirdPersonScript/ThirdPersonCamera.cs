using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] bool lockCursor;

    [SerializeField] float mouseSensitivity = 10;
    [SerializeField] Transform focusPoint;
    [SerializeField] float distFromFocusPoint = 2;
    [SerializeField] Vector2 MinMaxTurning = new Vector2(-40, 85);

    [SerializeField] float rotationSmoothTime = .12f;
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    float yaw;
    float pitch;
    private void Start()
    {
        if(lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;

            Cursor.visible = false;
        }
    }
    private void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X");
        pitch -= Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, MinMaxTurning.x, MinMaxTurning.y);

        currentRotation = Vector3.SmoothDamp(currentRotation,new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);

        //Vector3 targetRotation = new Vector3(pitch, yaw);
        //transform.eulerAngles = targetRotation;
        transform.eulerAngles = currentRotation;

        transform.position = focusPoint.position - transform.forward * distFromFocusPoint;
    }
}

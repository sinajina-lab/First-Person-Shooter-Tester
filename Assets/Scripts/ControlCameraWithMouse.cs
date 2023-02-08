using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace dMAN.FPS.CCC
{
    public class ControlCameraWithMouse : MonoBehaviour
    {
        [SerializeField] GameObject Camera;
        [SerializeField] float lookAtSpeed;
        [SerializeField] float horizontalMouseDirection;
        [SerializeField] float verticalMouseDirection;
        [SerializeField] float miniLookAngle = -60f;
        [SerializeField] float maxLookAngle = 60f;

        // Update is called once per frame
        void Update()
        {
            ///Controls the Player to look left and right
            horizontalMouseDirection = Input.GetAxis("Mouse X");
            transform.Rotate(0, horizontalMouseDirection, 0);
            /*transform.Rotate(0, horizontalMouseDirection * lookAtSpeed, 0);
            Debug.Log("Mouse X direction" + horizontalMouseDirection); */


            ///Controls the Camera to look up and down
            verticalMouseDirection = Input.GetAxis("Mouse Y");
            Camera.transform.Rotate(verticalMouseDirection, 0, 0);
            /*Camera.transform.Rotate(verticalMouseDirection * lookAtSpeed, 0, 0);
            Camera.transform.Rotate(-verticalMouseDirection, 0, 0);
            Debug.Log("Mouse Y direction" + verticalMouseDirection); */


            // Apply the limits to the camera's up and down rotation
            if (Camera.transform.localEulerAngles.x > 180f)
            {
                float angle = Camera.transform.localEulerAngles.x - 360f;
                angle = Mathf.Clamp(angle, miniLookAngle, maxLookAngle);
                Camera.transform.localEulerAngles = new Vector3(angle, 0f, 0f);
            }
            else
            {
                float angle = Mathf.Clamp(Camera.transform.localEulerAngles.x, miniLookAngle, maxLookAngle);
                Camera.transform.localEulerAngles = new Vector3(angle, 0f, 0f);
            }
        }
    }
}

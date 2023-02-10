using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTesting : MonoBehaviour
{
    [SerializeField] LayerMask mask;

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;
/*
        //QueryTriggerInteraction Ignore never report trigger hits
        if (Physics.Raycast(ray, out hitInfo, 100, mask, QueryTriggerInteraction.Ignore))
        {
            print(hitInfo.collider.gameObject.name);
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
        }
*/
        if (Physics.Raycast(ray, out hitInfo, 100, mask))
        {
            print(hitInfo.collider.gameObject.name);
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);

            //Destroy(hitInfo.transform.gameObject);
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.green);
        }
    }
}

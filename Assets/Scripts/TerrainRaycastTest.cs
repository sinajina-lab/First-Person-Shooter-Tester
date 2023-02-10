using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainRaycastTest : MonoBehaviour
{
    [SerializeField] Transform objectToPlace;
    [SerializeField] Camera gameCamera;

    // Update is called once per frame
    void Update()
    {
        Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo))
        {
            objectToPlace.position = hitInfo.point;
            objectToPlace.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }
    }
}

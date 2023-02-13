using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceAnimation : MonoBehaviour
{
    [SerializeField] float bounceSpeed = 8;
    [SerializeField] float bounceAmplitude = .05f;
    [SerializeField] float rotationSpeed = 90;

    float startingHeight;
    float timeOffset;

    // Start is called before the first frame update
    void Start()
    {
        startingHeight = transform.localPosition.y;
        timeOffset = Random.value * Mathf.PI * 2;
    }

    // Update is called once per frame
    void Update()
    {
        //Bounce animation
        float finalHeight = startingHeight + Mathf.Sin(Time.time * bounceAmplitude + timeOffset) * bounceAmplitude;
        var position = transform.localPosition;
        position.y = finalHeight;
        transform.localPosition = position;

        //Spin
        Vector3 rotation = transform.localRotation.eulerAngles;
        rotation.y += rotationSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
    }
}

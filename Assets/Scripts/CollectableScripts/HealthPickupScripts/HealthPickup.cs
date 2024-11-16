 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] float amount = 50;

    private void OnTriggerEnter(Collider other)
    {
        Health health = other.GetComponent<Health>();

        if(health)
        {
            //health.Heal(amount);
            Destroy(gameObject);
        }
    }
}

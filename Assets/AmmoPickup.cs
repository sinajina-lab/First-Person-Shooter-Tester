using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class AmmoPickup : MonoBehaviour
{
    //[SerializeField] GameObject bulletpickup;
    //[SerializeField] protected short bulletPoints;

    protected void OnTriggerEnter(Collider other)
    {
        Gun gun = other.gameObject.GetComponent<Gun>();
        if(gun)
        {
            gun.AddAmmo(gun.maxAmmo);
            Destroy(gameObject);
        }
    }
}

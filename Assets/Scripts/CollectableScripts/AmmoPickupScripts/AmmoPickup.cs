using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class AmmoPickup : MonoBehaviour
{
    // [SerializeField] GameObject bulletpickup;
    // [SerializeField] protected short bulletPoints;
    [SerializeField] AudioSource collectSound;

    protected void OnTriggerEnter(Collider other)
    {
        collectSound.Play();

        Gun gun = other.gameObject.GetComponent<Gun>();

        if (gun)
        {
            gun.AddAmmo(gun.maxAmmo);
            Destroy(gameObject);
        }

        //Can only cllect if you have 0 ammo
       /* if (gun.currentAmmo <=  0)
        {
            gun.AddAmmo(gun.maxAmmo);
            Destroy(gameObject);
        } */
    }
}

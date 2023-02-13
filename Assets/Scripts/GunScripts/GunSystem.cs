using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class GunSystem : MonoBehaviour
{
    //Gun stats
    [SerializeField] float damage;
    [SerializeField] float timeBtwnShooting, spread, range, reloadTime, timeBtwnShots;
    [SerializeField] float magazineSize, bulletsPerTap;
    [SerializeField] bool allowButtonHold;
    [SerializeField] float bulletsLeft, bulletsShot;

    //bools
    bool shooting, readyToShoot, reloading;

    //Reference
    [SerializeField] Camera fpsCam;
    [SerializeField] Transform attackPoint;
    [SerializeField] RaycastHit rayHit;
    [SerializeField] LayerMask whatIsEnemy;

    private void ShootingInput()
    {
        shooting = Input.GetKey(KeyCode.Mouse0);
        shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();

        //Shoot
        if(readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        readyToShoot = false;

        //Raycast
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out rayHit, whatIsEnemy))
        {
            Debug.Log(rayHit.collider.name);

            if(rayHit.collider.CompareTag("Enemy"))
            {

            }
        }
    }
    private void Reload()
    {
        readyToShoot = false;

        bulletsLeft--;
        Invoke("ResetShot", timeBtwnShooting);
    }
    private void ResetShot()
    {
        readyToShoot = true;
    }
    
}

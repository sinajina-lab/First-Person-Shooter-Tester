using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField] Camera fpsCam;

    [SerializeField] float damage;
    [SerializeField] float range = 100f;
    [SerializeField] float fireRate = 15f;
    [SerializeField] LayerMask enemyLayer;

    [SerializeField] int maxAmmo = 10;
    [SerializeField] int currentAmmo;
    [SerializeField] float reloadTime = 1f;
    bool isReloading = false;

   // [SerializeField] Animator animator;

    [SerializeField] ParticleSystem muzzleflash;
    [SerializeField] GameObject impactEffect;

    [SerializeField] float impactForce = 30f;
    [SerializeField] float nextTimeToFire = 0f;

    //Mouse button down(continuous)
    ///Cast a ray from the midle of the screen into the world
    ///Check if the ray has hit the target
    /// Cast a ray from the midle of the screen into the world
    private void Start()
    {
        currentAmmo = maxAmmo;
    }
    private void OnEnable()
    {
        isReloading = false;
       // animator.SetBool("Reloading", false);
    }
    private void Update()
    {
        muzzleflash.Play();

        currentAmmo--;

        if (isReloading)
            return;

        if(currentAmmo <= 0)
        {
            StartCoroutine(ReloadAmmo());
            return;
        }

        if(Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }
    IEnumerator ReloadAmmo()
    {
        isReloading = true;
        Debug.Log("Reloading...");

      //  animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - .25f);

       // animator.SetBool("Reloading", false);
       // yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;
        isReloading = false;
    }
    private void Shoot()
    {
        RaycastHit hitEnemy;
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

        if (Physics.Raycast(ray, out hitEnemy, 100, enemyLayer))
        {
            print(hitEnemy.collider.gameObject.name);
            Debug.DrawLine(ray.origin, hitEnemy.point, Color.red);

            hitEnemy.collider.gameObject.GetComponent<Target>().Injure(damage);

            if(hitEnemy.rigidbody != null)
            {
                hitEnemy.rigidbody.AddForce(-hitEnemy.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hitEnemy.point, Quaternion.LookRotation(hitEnemy.normal));
            Destroy(impactGO, .5f);

        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.green);
        }
    }
}

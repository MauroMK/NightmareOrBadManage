using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Gun basics
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 30f;
    private float nextTimeToFire = 0f;

    // FPS camera
    public Camera fpsCam;

    // Gun effects
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        // This prevents from calling muzzleFlash every frame, because the results are always the same:
        // seeing only the first ParticleSystem animation frame
        if( !muzzleFlash.isPlaying || muzzleFlash.time > (1f/muzzleFlash.emission.rateOverTime.constant) )
        {
            muzzleFlash.Play();
        }

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            // Debug.Log(hit.transform.name);

            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 1f);
        }
    }

}

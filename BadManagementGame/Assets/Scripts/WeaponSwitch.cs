using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{

    public int currentWeapon = 0;

    void Start()
    {
        SelectWeapon();
    }

    void Update()
    {

        int previousSelectedWeapon = currentWeapon;

        // Switching between weapons
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) {
            if (currentWeapon >= transform.childCount - 1) {
                currentWeapon = 0;
            } else
                currentWeapon++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f) {
            if (currentWeapon <= 0) {
                currentWeapon = transform.childCount - 1;
            } else
                currentWeapon--;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            currentWeapon = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            currentWeapon = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            currentWeapon = 3;
        }

        if (previousSelectedWeapon != currentWeapon)
        {
            SelectWeapon();
        }

    }

    void SelectWeapon() 
    {
        int i = 0;
        // Takes all of the Transforms that are child of the transform(weaponHolder) and loop through each one as weapon
        foreach (Transform weapon in transform) 
        {
            if (i == currentWeapon) // If the current i is the weapon, set her to true(show her), if not, hide it
            {
                weapon.gameObject.SetActive(true);
            } else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}

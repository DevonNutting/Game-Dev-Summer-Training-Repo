using UnityEngine;
using System.Collections;

public class Weapon : BaseWeapon
{
    
    public Transform firePoint;

    public override void Fire()
    {
        if (Time.time < nextFireTime) return; // Do nothing if we try to shoot before the weapon is ready to fire

        nextFireTime = Time.time + 1f / weaponData.fireRate; // Update the time it takes for each shot to be taken with the weapon

        if (weaponData.projectilePrefab != null && firePoint != null) // Check if the fire point and projectile prefab fields are not empty before trying to shoot
        {
            // Fire the weapon by spawning a bullet at the end of the weapon's barrel
            Instantiate(weaponData.projectilePrefab, firePoint.position, firePoint.rotation);
        } 
        else
        {
            Debug.LogWarning("Projectile Prefab or Fire point fields not set!");
        }

        // Play the fire sound
        Debug.Log("BANG)");
    }
}

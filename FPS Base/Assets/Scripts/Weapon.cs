using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    

    public GameObject projectilePrefab; 
    public Transform projectileSpawnPoint;
    public float projectileVelocity = 30f;
    public float projecileLifetime = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) Shoot();
    }

    private void Shoot()
    {
        // Instantiate projectile
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);

        // Add force to projectile
        projectile.GetComponent<Rigidbody>().AddForce(projectileSpawnPoint.forward.normalized * projectileVelocity, ForceMode.VelocityChange);

        StartCoroutine(DestroyProjectileAfterTime(projectile, projecileLifetime));

    }

    private IEnumerator DestroyProjectileAfterTime(GameObject projectile, float projectileLifeTime)
    {
        yield return new WaitForSeconds(projecileLifetime);
        Destroy(projectile);
    } 
}

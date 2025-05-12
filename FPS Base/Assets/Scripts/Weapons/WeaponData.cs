using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponData", menuName = "Weapons/Weapon Data")]
public class WeaponData : ScriptableObject
{
    [Tooltip("The display name of the weapon.")] 
    public string weaponName;
    [Tooltip("Number of shots the weapon can fire per second.")] 
    public float fireRate;
    [Tooltip("Maximum effective range of the weapon in meters.")] 
    public float range;
    [Tooltip("Total ammunition capacity.")] 
    public int ammoCapacity;
    [Tooltip("Number of seconds to reload the weaopon.")] 
    public float reloadSpeed;


    [Space(10), Tooltip("Prefab of the projectile to instantiate when firing.")] 
    public GameObject projectilePrefab;
    [Tooltip("Prefab of the weapon model.")] 
    public GameObject weaponPrefab;
    [Tooltip("Sound played when the weapon is fired.")] 
    public AudioClip fireSound;
}

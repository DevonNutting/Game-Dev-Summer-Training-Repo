using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    protected WeaponData weaponData;

    protected float nextFireTime = 0f;

    public virtual void Initialize(WeaponData data)
    {
        weaponData = data;
    }

    public abstract void Fire();

}

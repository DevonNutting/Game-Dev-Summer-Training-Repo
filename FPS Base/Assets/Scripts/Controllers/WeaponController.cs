using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public BaseWeapon equippedWeapon; // The currently equiped weapon of the player
    public WeaponData[] weapons; // An array of the weaponData for each weapon the player has in their inventory
    public Transform weaponHolder; // The container for the equipped weapon

    private int currentWeaponIndex = 0; // A counter to determine which weapon the player has equipped

    private void Start()
    {
        EquipWeapon(currentWeaponIndex);

        if (equippedWeapon == null) Debug.LogError("No Weapons to Equip!");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) equippedWeapon?.Fire();
    }

    private void EquipWeapon(int index)
    {
        if (index < 0 || index >= weapons.Length) return; // Do nothing if our index is below zero or at going over the actual number of weapons the player has

        if (equippedWeapon) // If the player already has a weapon equipped
        {
            Destroy(equippedWeapon.gameObject); // Destroy/Remove their current weapon to clear space for the newly equipped one
        }
        
        WeaponData weaponData = weapons[index]; // Find the weapondata for the newly equipped weapon

        // Instantiate the weapon prefab in the player's hands
        GameObject weaponToEquip = Instantiate(weaponData.weaponPrefab, weaponHolder);

        // Position the weapon
        weaponToEquip.transform.localPosition = Vector3.zero; // Position the weapon exacatly where the weapon holder object is
        weaponToEquip.transform.localRotation = Quaternion.identity; // Rotate the weapon to face forward

        equippedWeapon = weaponToEquip.GetComponent<Weapon>();
        equippedWeapon.Initialize(weaponData);

    }
    
}

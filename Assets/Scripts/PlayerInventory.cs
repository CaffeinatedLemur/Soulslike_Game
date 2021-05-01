using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NightBook
{
    public class PlayerInventory : MonoBehaviour
    {
        WeaponSlotManager weaponSlotManager;

        public WeaponItem rigtWeapon;
        public WeaponItem leftWeapon;

        private void Awake()
        {
            weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
        }

        private void Start()
        {
            weaponSlotManager.LoadWeaponOnSlot(rigtWeapon, false);
            weaponSlotManager.LoadWeaponOnSlot(leftWeapon, true);
        }
    }
}

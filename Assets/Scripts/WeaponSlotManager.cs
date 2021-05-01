using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NightBook
{
    public class WeaponSlotManager : MonoBehaviour
    {
        WeaponHolderSlot leftHandSlot;
        WeaponHolderSlot rigtHandSlot;

        public void Awake()
        {
            WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();
            foreach (WeaponHolderSlot weaponslot in weaponHolderSlots)
            {
                if (weaponslot.isLeftHandSlot)
                {
                    leftHandSlot = weaponslot;
                }
                else if (weaponslot.isRigtHandSlot)
                {
                    rigtHandSlot = weaponslot;
                }
            }
        }

        public void LoadWeaponOnSlot(WeaponItem weaponItem, bool isLeft)
        {
            if (isLeft)
            {
                leftHandSlot.LoadWeaponModel(weaponItem);
            }
            else
            {
                rigtHandSlot.LoadWeaponModel(weaponItem);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NightBook
{
    public class WeaponSlotManager : MonoBehaviour
    {
        WeaponHolderSlot leftHandSlot;
        WeaponHolderSlot rigtHandSlot;

        DamageCollider leftHandDamageCollider;
        DamageCollider rigtHandDamageCollider;

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
                LoadLeftWeaponDamageCollider();
            }
            else
            {
                rigtHandSlot.LoadWeaponModel(weaponItem);
                LoadRigtWeaponDamageCollider();
            }
        }

        #region Handle Weapon's Damage Collider
        private void LoadLeftWeaponDamageCollider()
        {
            leftHandDamageCollider = leftHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
        }

        private void LoadRigtWeaponDamageCollider()
        {
            rigtHandDamageCollider = rigtHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
        }

        private void OpenLeftDamageCollider()
        {
            leftHandDamageCollider.EnableDamageCollider();
        }

        private void OpenRigtDamageCollider()
        {
            rigtHandDamageCollider.EnableDamageCollider();
        }

        private void CloseLeftDamageCollider()
        {
            leftHandDamageCollider.DisableDamageCollider();
        }

        private void CloseRigtDamageCollider()
        {
            rigtHandDamageCollider.DisableDamageCollider();
        }

        #endregion

    }
}

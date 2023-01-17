using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    public class WeaponSlotManager : MonoBehaviour
    {
        WeaponHolderSlot leftHandSlot;
        WeaponHolderSlot rightHandSlot;
        DamageCollider leftHandDamageCollider;
        DamageCollider rightHandDamageCollider;

        [SerializeField]
        QuickSlotUI quickSlotUI;

        Animator anim;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            quickSlotUI = FindObjectOfType<QuickSlotUI>();
            WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();

            foreach (WeaponHolderSlot slot in weaponHolderSlots)
            {
                if (slot.isLeftHandSlot)
                {
                    leftHandSlot = slot;
                }
                else if (slot.isRightHandSlot)
                {
                    rightHandSlot = slot;
                }
            }
        }

       

        public void LoadWeaponOnSlot (WeaponItem weaponItem, bool isLeft)
        {
            if (isLeft)
            {
                leftHandSlot.LoadWeaponModel(weaponItem);
                LoadLeftWeaponDamageCollider();
                

                #region Handle left weapon Idle Animation
                if (weaponItem != null)
                {
                    anim.CrossFade(weaponItem.leftHandIdle, 0.2f);
                }
                else
                {
                    anim.CrossFade("LeftArmEmpty", 0.2f);
                }
                #endregion
            }
            else
            {
                rightHandSlot.LoadWeaponModel(weaponItem);
                LoadRightWeaponDamageCollider();
                

                #region Handle right weapon Idle Animation
                if (weaponItem != null)
                {
                    anim.CrossFade(weaponItem.rightHandIdle, 0.2f);
                }
                else
                {
                    anim.CrossFade("RightArmEmpty", 0.2f);
                }
                #endregion
            }
            quickSlotUI.UpdateWeaponQuickSlotsUI(isLeft, weaponItem);
        }

        #region Handle weapon collider
        private void LoadLeftWeaponDamageCollider()
        {
            leftHandDamageCollider = leftHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
        }

        private void LoadRightWeaponDamageCollider()
        {
            rightHandDamageCollider = rightHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
        }

        public void OpenLeftDamageCollider()
        {
            leftHandDamageCollider.EnableDamageCollider();
        }

        public void OpenRightDamageCollider()
        {
            rightHandDamageCollider.EnableDamageCollider();
        }

        public void CloseLeftDamageCollider()
        {
            leftHandDamageCollider.DisableDamageCollider();
        }

        public void CloseRightDamageCollider()
        {
            rightHandDamageCollider.DisableDamageCollider();
        }
        #endregion




    }

}

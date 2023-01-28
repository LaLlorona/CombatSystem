using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    public class WeaponSlotManager : MonoBehaviour
    {
        WeaponHolderSlot leftHandSlot;
        WeaponHolderSlot rightHandSlot;
        WeaponHolderSlot backSlot;
        AnimatedController animatedController;
        DamageCollider leftHandDamageCollider;
        DamageCollider rightHandDamageCollider;

        public CharacterInventory characterInventory;

        [SerializeField]
        QuickSlotUI quickSlotUI;

        Animator anim;

        public InputReader input;

        public bool isTwoHandedHolding = false;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            quickSlotUI = FindObjectOfType<QuickSlotUI>();
            animatedController = GetComponent<AnimatedController>();
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

                else if (slot.isBackSlot)
                {
                    backSlot = slot;
                }
            }
        }

        //private void OnEnable()
        //{
        //    input.onYbuttonInput += ToggleIsTwoHanded;
        //}

        //private void OnDisable()
        //{
        //    input.onYbuttonInput -= ToggleIsTwoHanded;
        //}



        //public void LoadWeaponOnSlot (WeaponItem weaponItem, bool isLeft)
        //{
        //    if (isLeft)
        //    {
        //        leftHandSlot.currentWeapon = weaponItem;
        //        leftHandSlot.LoadWeaponModel(weaponItem);
        //        LoadLeftWeaponDamageCollider();
        //        quickSlotUI.UpdateWeaponQuickSlotsUI(isLeft, weaponItem);

        //        #region Handle left weapon Idle Animation
        //        if (weaponItem != null)
        //        {
        //            anim.CrossFade(weaponItem.leftHandIdle, 0.2f);
        //        }
        //        else
        //        {
        //            anim.CrossFade("LeftArmEmpty", 0.2f);
        //        }
        //        #endregion
        //    }
        //    else
        //    {
        //        if (isTwoHandedHolding)
        //        {
        //            backSlot.LoadWeaponModel(leftHandSlot.currentWeapon);
        //            leftHandSlot.UnloadWeaponAndDestroy();
        //            anim.CrossFade(weaponItem.twoHandIdle, 0.2f);
        //        }
        //        else
        //        {
        //            anim.CrossFade("Both Arms Empty", 0.2f);

        //            backSlot.UnloadWeaponAndDestroy();

        //            #region Handle right weapon Idle Animation
        //            if (weaponItem != null)
        //            {
        //                anim.CrossFade(weaponItem.rightHandIdle, 0.2f);
        //            }
        //            else
        //            {
        //                anim.CrossFade("RightArmEmpty", 0.2f);
        //            }


        //            #endregion
        //        }
        //        rightHandSlot.currentWeapon = weaponItem;
        //        rightHandSlot.LoadWeaponModel(weaponItem);
        //        LoadRightWeaponDamageCollider();
        //        quickSlotUI.UpdateWeaponQuickSlotsUI(isLeft, weaponItem);
        //        Debug.Log(weaponItem.weaponController);
        //        animatedController.anim.runtimeAnimatorController = weaponItem.weaponController;

                

        //    }
        //}

        //public void ToggleIsTwoHanded()
        //{
        //    isTwoHandedHolding = !isTwoHandedHolding;

        //    if (isTwoHandedHolding)
        //    {
        //        LoadWeaponOnSlot(characterInventory.rightWeapon, false);
        //    }
        //    else
        //    {
        //        LoadWeaponOnSlot(characterInventory.rightWeapon, false);
        //        LoadWeaponOnSlot(characterInventory.leftWeapon, true);
        //    }
        //}

        //public void TwoHandGrap(WeaponItem weaponItem)
        //{
        //    anim.CrossFade(weaponItem.twoHandIdle, 0.2f);
            
        //}

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

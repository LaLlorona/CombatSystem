using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    public class WeaponSlotManager : MonoBehaviour
    {
        public WeaponHolderSlot leftHandSlot;
        public WeaponHolderSlot rightHandSlot;
        public WeaponHolderSlot backSlot;


        public CharacterInventory characterInventory;
        public MainCharacterManager mainCharacterManager;

  
        public void FindWeaponSlotsOfCurrentCharacter()
        {
            WeaponHolderSlot[] weaponHolderSlots = mainCharacterManager.currentIndividualCharacterManager.gameObject.GetComponentsInChildren<WeaponHolderSlot>();
          
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

        public void LoadWeaponOnHand(WeaponItem weaponItem)
        {
            FindWeaponSlotsOfCurrentCharacter();
            
            if (mainCharacterManager.currentWeaponType == WeaponType.Sword || mainCharacterManager.currentWeaponType == WeaponType.Wand)
            {
                rightHandSlot.currentWeapon = weaponItem;
                rightHandSlot.LoadWeaponModel(weaponItem);

            }

            else if (mainCharacterManager.currentWeaponType == WeaponType.Knuckle)
            {
                rightHandSlot.currentWeapon = weaponItem;
                rightHandSlot.LoadWeaponModel(weaponItem);

                Debug.Log(mainCharacterManager.currentIndividualCharacterManager.gameObject.name);
                leftHandSlot.currentWeapon = weaponItem;
                leftHandSlot.LoadWeaponModel(weaponItem);
            }
            
        }

        public void LoadWeaponOnBack(WeaponItem weaponItem)
        {
            if (mainCharacterManager.currentWeaponType == WeaponType.Sword || mainCharacterManager.currentWeaponType == WeaponType.Wand)
            {

            }

            else if (mainCharacterManager.currentWeaponType == WeaponType.Knuckle)
            {
                Debug.Log("this character do not need to unload weapon");
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





    }

}

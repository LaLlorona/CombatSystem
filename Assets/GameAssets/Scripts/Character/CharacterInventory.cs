using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    public class CharacterInventory : MonoBehaviour
    {
        const int NUM_ITEM_IN_HAND = 4;
        const int UNARMED_ITEM_INDEX = -1;

        WeaponSlotManager weaponSlotManager;
        public WeaponItem rightWeapon;
        public WeaponItem leftWeapon;

        public WeaponItem unarmedWeapon;
        public InputReader input;

        

        public WeaponItem[] weaponsInRightHandSlots = new WeaponItem[NUM_ITEM_IN_HAND];
        public WeaponItem[] weaponsInLeftHandSlots = new WeaponItem[NUM_ITEM_IN_HAND];

        public int currentRightWeaponIndex = 0;
        public int currentLeftWeaponIndex = 0;

        public List<WeaponItem> weaponsInventory;

        private void Awake()
        {
            weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
            
        }

        //private void Start()
        //{
        //    rightWeapon = weaponsInRightHandSlots[currentRightWeaponIndex];
        //    leftWeapon = weaponsInLeftHandSlots[currentLeftWeaponIndex];
        //    weaponSlotManager.LoadWeaponOnSlot(rightWeapon, false);
        //    weaponSlotManager.LoadWeaponOnSlot(leftWeapon, true);
        //}

        //private void Update()
        //{
        //    HandleQuickSlotInput();

        //}

        //public void ChangeRightWeapon()
        //{
        //    currentRightWeaponIndex += 1;
        //    if (currentRightWeaponIndex >= NUM_ITEM_IN_HAND || weaponsInRightHandSlots[currentRightWeaponIndex] == null) 
        //    {
        //        currentRightWeaponIndex = 0;
        //    }   
        //    rightWeapon = weaponsInRightHandSlots[currentRightWeaponIndex];
        //    weaponSlotManager.LoadWeaponOnSlot(rightWeapon, false); 
        //}

        //public void ChangeLeftWeapon()
        //{
        //    currentLeftWeaponIndex += 1;
        //    if (currentLeftWeaponIndex >= NUM_ITEM_IN_HAND || weaponsInLeftHandSlots[currentLeftWeaponIndex] == null)
        //    {
        //        currentLeftWeaponIndex = 0;
        //    }
        //    leftWeapon = weaponsInLeftHandSlots[currentLeftWeaponIndex];
        //    weaponSlotManager.LoadWeaponOnSlot(leftWeapon, true);
        //}

        //private void HandleQuickSlotInput()
        //{
        //    if (input.dPadRight)
        //    {
        //        ChangeRightWeapon();
        //        input.dPadRight = false;
        //    }

        //    if (input.dPadLeft)
        //    {
        //        ChangeLeftWeapon();
        //        input.dPadLeft = false;
        //    }
        //}
    }

}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//namespace KMK
//{
//    public class WeaponInventorySlot : MonoBehaviour
//    {
//        public Image icon;
//        WeaponItem item;

//        public CharacterInventory characterInventory;
//        public WeaponSlotManager weaponSlotManager;
//        public UIManager uiManager;
        

//        private void Awake()
//        {
//            characterInventory = FindObjectOfType<CharacterInventory>();
//            uiManager = FindObjectOfType<UIManager>();
//            weaponSlotManager = FindObjectOfType<WeaponSlotManager>();
//        }

//        public void CloseAllWindows()
//        {
//            uiManager.CloseAllInventoryWindows();
//        }



//        public void EquipThisItem()
//        {
//            bool isLeft = uiManager.isLeftHand;
//            int slotIndex = uiManager.slotIndex;

//            if (slotIndex == -1)
//            {
//                Debug.Log("no item is selected ");
//                return;
//            }

//            characterInventory.weaponsInventory.Remove(item);

//            if (isLeft)
//            {
//                if (characterInventory.weaponsInLeftHandSlots[slotIndex] != null)
//                {
//                    characterInventory.weaponsInventory.Add(characterInventory.weaponsInLeftHandSlots[slotIndex]);
//                }
                
//                characterInventory.weaponsInLeftHandSlots[slotIndex] = item;
//                characterInventory.leftWeapon = item;
                

                

//            }
//            else
//            {
//                if (characterInventory.weaponsInRightHandSlots[slotIndex] != null)
//                {
//                    characterInventory.weaponsInventory.Add(characterInventory.weaponsInRightHandSlots[slotIndex]);
//                }
                
//                characterInventory.weaponsInRightHandSlots[slotIndex] = item;
//                characterInventory.rightWeapon = item;



//            }
//            //weaponSlotManager.LoadWeaponOnSlot(characterInventory.rightWeapon, false);
//            //weaponSlotManager.LoadWeaponOnSlot(characterInventory.leftWeapon, true);

//            uiManager.equipmentWindowUI.LoadWeaponsOnEquipmentScreen(characterInventory);
//            uiManager.ResetAllSelectedSlots();



//            //add current item in hand to inventory

//            //equip this new item

//            //remove this item from inventory 

//            //Remove current item
//        }

//        public void AddItem(WeaponItem newItem)
//        {
//            item = newItem;
//            icon.sprite = item.itemIcon;
//            icon.enabled = true;
//            gameObject.SetActive(true);
//        }

//        public void ClearItem()
//        {
//            item = null;
//            icon.sprite = null;
//            icon.enabled = false;
//            gameObject.SetActive(false);
//        }
//    }
//}


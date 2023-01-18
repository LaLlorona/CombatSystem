using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    public class UIManager : MonoBehaviour
    {
        public CharacterInventory characterInventory;
        public EquimentWindowUI equipmentWindowUI;
        public InputReader input;

        [Header("UI windows")]
        public GameObject selectWindow;
        public GameObject inventoryWindow;
        public GameObject hudWindow;

        [Header("Weapon Inventory")]

        public GameObject weaponInventorySlotPrefab;
        public Transform weaponInventorySlotsParent;
        List<WeaponInventorySlot> weaponInventorySlots = new List<WeaponInventorySlot>();

        public void UpdateUI()
        {
            #region Weapon inventory slots
          
            weaponInventorySlots.Clear();
            int numChildCount = weaponInventorySlotsParent.childCount;
            for (int i = 0; i < numChildCount; i++)
            {
                Destroy(weaponInventorySlotsParent.GetChild(i).gameObject);
            }

            for (int i = 0; i < characterInventory.weaponsInventory.Count; i++)
            {
                GameObject newWeaponSlotGameobject =  Instantiate(weaponInventorySlotPrefab, weaponInventorySlotsParent);
                WeaponInventorySlot newWeaponSlot = newWeaponSlotGameobject.GetComponent<WeaponInventorySlot>();
                newWeaponSlot.AddItem(characterInventory.weaponsInventory[i]);
                weaponInventorySlots.Add(newWeaponSlot);
            }
            

            #endregion
        }

        private void Start()
        {
            equipmentWindowUI.LoadWeaponsOnEquipmentScreen(characterInventory);
        }

        public void CloseAllInventoryWindows()
        {
            inventoryWindow.SetActive(false);
        }


        private void OnEnable()
        {
            input.OnInventoryInput += ToggleSelectWindow;
            
        }

        private void OnDisable()
        {
            input.OnInventoryInput -= ToggleSelectWindow;
        }


        public void ToggleSelectWindow()
        {
            Debug.Log($"toggle select window, and current state is {selectWindow.activeSelf}");
            if (selectWindow.activeSelf)
            {
                selectWindow.SetActive(false);
                
                CloseAllInventoryWindows();
                hudWindow.SetActive(true);
            }
            else
            {
                selectWindow.SetActive(true);
                UpdateUI();
                hudWindow.SetActive(false);
            }
            
        }

        
    }
}


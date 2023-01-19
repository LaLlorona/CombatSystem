using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KMK
{
    public class EquipmentSlotUI : MonoBehaviour
    {
        public Image icon;
        public UIManager uiManager;
        WeaponItem weapon;

        public bool isLeftHand;

        public int slotIndex;

        public void SelectThisSlot()
        {
            uiManager.isLeftHand = isLeftHand;
            uiManager.slotIndex = slotIndex;
        }

        public void AddItem(WeaponItem newWeapon)
        {
            if(newWeapon == null)
            {
                return;
            }
            weapon = newWeapon;
            icon.sprite = weapon.itemIcon;
            icon.enabled = true;
            gameObject.SetActive(true);
        }

        public void ClearItem()
        {
            weapon = null;
            icon.sprite = null;
            icon.enabled = false;
            gameObject.SetActive(false);
        }
    }

}

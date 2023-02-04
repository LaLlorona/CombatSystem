//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//namespace KMK
//{
//    public class EquimentWindowUI : MonoBehaviour
//    {
//        public int rightHandSelectIndex = 0;
//        public int leftHandSelectIndex = 0;
//        const int NUM_ITEM_IN_HAND = 4;

//        public EquipmentSlotUI[] equipmentSlotUIs;

//        private void Awake()
//        {
      
//        }

//        public void LoadWeaponsOnEquipmentScreen(CharacterInventory characterInventory)
//        {
//            for (int i = 0; i < equipmentSlotUIs.Length; i++)
//            {
//                if (equipmentSlotUIs[i].isLeftHand) // 4, 5, 6, 7
//                {
//                    equipmentSlotUIs[i].AddItem(characterInventory.weaponsInLeftHandSlots[i - NUM_ITEM_IN_HAND]);
//                }
//                else
//                {
//                    equipmentSlotUIs[i].AddItem(characterInventory.weaponsInRightHandSlots[i]);
//                }
//            }
//        }
//        public void SelecRightSlot(int index)
//        {
//            rightHandSelectIndex = index;
//            Debug.Log($"rigiht slot {index}");
//        }

//        public void SelectLeftSlot(int index)
//        {
//            leftHandSelectIndex = index;
//            Debug.Log($"left slot {index}");
//        }
       
//    }

//}

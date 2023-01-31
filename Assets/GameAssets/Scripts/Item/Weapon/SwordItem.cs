using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace KMK
{
    [CreateAssetMenu(menuName = "Items/Weapon Item/Sword Item")]
    public class SwordItem : WeaponItem
    {
        private void OnEnable()
        {
            weaponType = WeaponType.Sword;
        }
    }

}

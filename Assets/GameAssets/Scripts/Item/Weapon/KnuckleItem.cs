using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    [CreateAssetMenu(menuName = "Items/Weapon Item/Knuckle Item")]
    public class KnuckleItem : WeaponItem
    {
        private void OnEnable()
        {
            weaponType = WeaponType.Knuckle;
        }
    }

}

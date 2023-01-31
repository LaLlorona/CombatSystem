using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    [CreateAssetMenu(menuName = "Items/Weapon Item/Wand Item")]
    public class WandItem : WeaponItem
    {

        public ProjectileItem projectileItem;
      
        private void OnEnable()
        {
            weaponType = WeaponType.Wand;
        }
    }

}

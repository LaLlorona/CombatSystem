using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    [CreateAssetMenu(menuName = "Items/Weapon Item")]
    public class WeaponItem :Item
    {
        public GameObject modelPrefab;
        //public bool isUnarmed;

        

        [Header("WeaponType")]
        
        public WeaponType weaponType;

        [Header("Weapon Art Animation Name")]
        public string weaponArtName = "weaponArtAnimation"; //weapon art is a skill played when user press 'weapon art' button
        

        

    }
}


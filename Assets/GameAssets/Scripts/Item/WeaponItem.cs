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
        

        

        

        //[Header("One Handed Attack Animations")]
        //public string oneHandHeavyAttack1;
        //public string oneHandHeavyAttack2;

        //public string oneHandLightAttack1;
        //public string oneHandLightAttack2;

        //[Header("Idle Animations")]
        //public string rightHandIdle;
        //public string leftHandIdle;
        //public string twoHandIdle;

        //[Header("Stamina cost")]
        //public int baseStaminaDrain;
        //public float lightAttackMultiplier;
        //public float heavyAttackMultiplier;

    }
}


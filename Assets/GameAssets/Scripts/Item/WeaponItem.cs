using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    [CreateAssetMenu(menuName = "Items/Weapon Item")]
    public class WeaponItem :Item
    {
        public GameObject modelPrefab;
        public bool isUnarmed;

        [Header("One Handed Attack Animations")]
        public string oneHandHeavyAttack1;
        public string oneHandLightAttack1;

    }
}


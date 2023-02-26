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

        public float baseDamage;

        

        [Header("WeaponType")]
        
        public WeaponType weaponType;

        public SkillType skillType;

        [Header("Weapon Art Animation Name")]
        public string weaponArtName = "weaponArtAnimation"; //weapon art is a skill played when user press 'weapon art' button


        public Skill weaponSkill;
        public float weaponMpConsume;

    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    [CreateAssetMenu(menuName = "Items/Character Item")]
    public class CharacterItem : Item
    {
        [Header("animator Replacer")]
        public AnimatorOverrideController weaponController;

        public int characterLevel;
        

        public WeaponType aviableWeaponType;

        

        public Skill qteSkill;

        public string qteArtName = "qteArtAnimation"; //qte is a skill played when user change to this character while satisfying the condition

        public List<AttackAdditionalEffect> qteConditions;
    }

}

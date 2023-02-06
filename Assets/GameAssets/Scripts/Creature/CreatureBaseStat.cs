using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace KMK
{
    [CreateAssetMenu(menuName = "Creature/CreatureStat")]
    public class CreatureBaseStat : ScriptableObject
    {
        public int maxHealth;
        public int maxMana;
        public int strength;
        public int magic;
        public int defense;
        public int magicDefense;
        

    }

}

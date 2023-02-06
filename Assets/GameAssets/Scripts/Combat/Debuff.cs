using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    [CreateAssetMenu(menuName = "AttackAdditionalEffect/Debuff")]
    public class Debuff :AttackAdditionalEffect
    {
        public DebuffType debuffType; 
        public float debuffAmount;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    public class CharacterCreature : Creature
    {
        public bool isCharacterActive = false;
        // Start is called before the first frame update
        public override void OnDamage(Attack attack)
        {
            if (isCharacterActive)
            {
                base.OnDamage(attack);
                MainCharacterManager.Instance.currentCharacterAnimatedController.PlayTargetAnimation("Damaged", true, 0.2f, false, false);

            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationEventHandler : MonoBehaviour
{
    public delegate void CharacterAnimationEvent();

    public CharacterAnimationEvent onAttackStaminaDrain;

    public void DrainStaminaOnAttack()
    {
        onAttackStaminaDrain?.Invoke();
    }
}

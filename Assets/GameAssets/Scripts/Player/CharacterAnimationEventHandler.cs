using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationEventHandler : MonoBehaviour
{
    public delegate void CharacterAnimationEvent();

    public CharacterAnimationEvent onAttackStaminaDrain;
    public CharacterAnimationEvent onEnableRotate;
    public CharacterAnimationEvent onEnableBaseAttack;

    

    public void DrainStaminaOnAttack()
    {
        onAttackStaminaDrain?.Invoke();
    }

    public void TurnOnRotate()
    {
        onEnableRotate?.Invoke();
    }

    public void OnEnableNextbaseAttack()
    {
        onEnableBaseAttack?.Invoke();
    }
}

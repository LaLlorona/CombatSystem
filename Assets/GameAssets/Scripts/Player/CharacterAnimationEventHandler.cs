using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationEventHandler : MonoBehaviour
{
    public delegate void CharacterAnimationEvent();

    public CharacterAnimationEvent onAttackStaminaDrain;


    public CharacterAnimationEvent onEnableBaseAttack;
    public CharacterAnimationEvent onAttackOpen;
    public CharacterAnimationEvent onAttackClose;

    public CharacterAnimationEvent onSkillOpen;
    public CharacterAnimationEvent onSkillClose;

    

    

    public void DrainStaminaOnAttack()
    {
        onAttackStaminaDrain?.Invoke();
    }

    public void OnEnableNextbaseAttack()
    {
        onEnableBaseAttack?.Invoke();
    }

    public void OnAttackOpen()
    {
        onAttackOpen?.Invoke();
    }

    public void OnAttackClose()
    {
        onAttackClose?.Invoke();
    }

    public void OnSkillOpen()
    {
        onSkillOpen?.Invoke();
    }

    public void OnSkillClose()
    {
        onSkillClose?.Invoke();
    }

}

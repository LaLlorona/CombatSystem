using System;
using System.Collections;
using System.Collections.Generic;
using KMK;
using Unity.VisualScripting;
using UnityEngine;
using static KMK.AnimationNameDefine;

public class CharacterSkillHandler : MonoBehaviour
{
    private void OnEnable()
    {
       
        MainCharacterManager.Instance.onCharacterChange += SetCharacterSkinIconInfo;
        MainCharacterManager.Instance.onCharacterChange += CheckSkillAvailabilityAndSetUI;

    }
    
    private void OnDisable()
    {
        MainCharacterManager.Instance.onCharacterChange -= SetCharacterSkinIconInfo;
        MainCharacterManager.Instance.onCharacterChange -= CheckSkillAvailabilityAndSetUI;
    }
    
    public void SetCharacterSkinIconInfo(int index)
    {
        WeaponItem weaponItem = MainCharacterManager.Instance.individualCharacterManagers[index]
            .characterWeapon;
        Sprite currentCharacterWeaponSkillIcon = weaponItem.weaponSkillSprite;
        float weaponMpConsume = weaponItem.weaponMpConsume;
        UIManager.Instance.SetSkillIconInfo(currentCharacterWeaponSkillIcon, weaponMpConsume);
    }
    
    public bool CanUseWeaponArt()
    {
        IndividualCharacterManager currentCharacterManager =
            MainCharacterManager.Instance.currentIndividualCharacterManager;
        return currentCharacterManager.characterCreature.currentMp >=
               currentCharacterManager.characterWeapon.weaponMpConsume;
    }

    public void UseWeaponArt()
    {
        if (CanUseWeaponArt())
        {
            MainCharacterManager.Instance.currentIndividualCharacterManager.characterCreature.ChangeMpValue(-MainCharacterManager.Instance.currentIndividualCharacterManager.characterWeapon.weaponMpConsume); 
                    
            Debug.Log($"current character name is {MainCharacterManager.Instance.currentIndividualCharacterManager.characterItemInfo.itemName}");
            MainCharacterManager.Instance.currentCharacterAnimatedController.anim.SetBool(isAttackingHash, true);
            MainCharacterManager.Instance.currentCharacterAnimatedController.PlayTargetAnimation(MainCharacterManager.Instance.currentIndividualCharacterManager.characterWeapon.weaponArtName,
                true, 0.2f);
        }
            
    }

    public void CheckSkillAvailabilityAndSetUI(int n)
    {
        UIManager.Instance.ToggleSkillEnable(CanUseWeaponArt());
    }
    
    
}

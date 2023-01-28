using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    public class IndividualCharacterManager : MonoBehaviour
    {
        [Header("Reference")]
        public AnimatedController animatedController;
        public CharacterAnimationEventHandler characterAnimationEventHandler;
        public GameObject individualCharacterGameobject;

        [Header("Character Info")]
        

        public float maxHp;
        public float currentHP;

        public float maxMp;
        public float currentMp;

        public WeaponItem characterWeapon;
        public CharacterItem characterItemInfo;

        private void Awake()
        {
            individualCharacterGameobject = transform.GetChild(0).gameObject;
            animatedController = individualCharacterGameobject.GetComponent<AnimatedController>();
            characterAnimationEventHandler = individualCharacterGameobject.GetComponent<CharacterAnimationEventHandler>();

            
        }
    }

}

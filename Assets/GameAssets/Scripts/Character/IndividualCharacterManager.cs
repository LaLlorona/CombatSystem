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




        [Header("Character Info")] public int characterIndex;
        public CharacterCreature characterCreature;

        //public float maxHp;
        //public float currentHp;

        //public float maxMp;
        //public float currentMp;

        public WeaponItem characterWeapon;
        public CharacterItem characterItemInfo;


        [Header("Character Change Information")]
        private float characterChangeCooltime = 10f;
        private float characterChangeRemainTime;
        private float timerInterval = 0.1f;

        public bool canChangeCharacter = true;
        
        private void Awake()
        {
            individualCharacterGameobject = transform.GetChild(0).gameObject;
            animatedController = individualCharacterGameobject.GetComponent<AnimatedController>();
            characterAnimationEventHandler = individualCharacterGameobject.GetComponent<CharacterAnimationEventHandler>();
            characterCreature = GetComponent<CharacterCreature>();

        }

        public void BeginCharacterChangeTimer()
        {
            canChangeCharacter = false;
            characterChangeRemainTime = characterChangeCooltime;
            StartCoroutine(StartCharacterChangeTimer());
        }
        

        IEnumerator StartCharacterChangeTimer()
        {
            while (characterChangeRemainTime >= 0)
            {
                characterChangeRemainTime -= timerInterval;
                UIManager.Instance.SetPortraitMaskRatio(characterIndex, characterChangeRemainTime / characterChangeCooltime);
                yield return new WaitForSeconds(timerInterval);
            }

            canChangeCharacter = true;
        }
        
        
    }

}

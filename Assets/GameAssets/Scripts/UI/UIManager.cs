using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace KMK
{
    public class UIManager : Singleton<UIManager>
    {
        [Header("HP UI setting")]
        public GameObject healthBar;
        public Slider hpSlider;
        public TextMeshProUGUI hpNumber;

        [Header("MP UI setting")]
        public GameObject mpBar;
        public Slider mpSlider;
        public TextMeshProUGUI mpNumber;


        [Header("QTE UI Setting")] 
        public List<GameObject> qteIndicators;

        public List<Image> coolTimeMasks;

        

   


        #region private

        private float maxHp;
        private float currentHp;

        private float maxMp;
        private float currentMp;

        #endregion

        


        public void SetHPUI()
        {
            CharacterCreature currentCreature = MainCharacterManager.Instance.currentIndividualCharacterManager.characterCreature;
            currentHp = currentCreature.currentHealth;
            maxHp = currentCreature.maxHealth;
            hpSlider.value = currentHp / maxHp;
            hpNumber.text = BuildText(currentHp, maxHp);
        }

        public void SetMPUI()
        {
            CharacterCreature currentCreature = MainCharacterManager.Instance.currentIndividualCharacterManager.characterCreature;

            currentMp = currentCreature.currentMp;
            maxMp = currentCreature.maxMp;
            mpSlider.value = currentMp / maxMp;
            mpNumber.text = BuildText(currentMp, maxMp);

        }

        private string BuildText(float currentValue, float maxValue)
        {
            return $"{(int)currentValue} / {(int)maxValue}";
        }

        public void ToggleQteIndicator(int index, bool toggle)
        {
            qteIndicators[index].SetActive((toggle));
        }

        public void SetPortraitMaskRatio(int index, float ratio)
        {
            coolTimeMasks[index].fillAmount = ratio;
        }
    }

}

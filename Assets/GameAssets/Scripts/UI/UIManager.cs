using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace KMK
{
    public class UIManager : MonoBehaviour
    {
        [Header("HP UI setting")]
        public GameObject healthBar;
        public Slider hpSlider;
        public TextMeshProUGUI hpNumber;

        [Header("MP UI setting")]
        public GameObject mpBar;
        public Slider mpSlider;
        public TextMeshProUGUI mpNumber;


        #region private

        private float maxHp;
        private float currentHp;

        private float maxMp;
        private float currentMp;

        #endregion

        


        public void SetHPUI()
        {
            currentHp = MainCharacterManager.Instance.currentIndividualCharacterManager.currentHp;
            maxHp = MainCharacterManager.Instance.currentIndividualCharacterManager.maxHp;
            hpSlider.value = currentHp / maxHp;
            hpNumber.text = BuildText(currentHp, maxHp);



        }

        public void SetMPUI()
        {
            currentMp = MainCharacterManager.Instance.currentIndividualCharacterManager.currentMp;
            maxMp = MainCharacterManager.Instance.currentIndividualCharacterManager.maxMp;
            mpSlider.value = currentMp / maxMp;
            mpNumber.text = BuildText(currentMp, maxMp);

        }

        public string BuildText(float currentValue, float maxValue)
        {
            return $"{(int)currentValue} / {(int)maxValue}";
        }
    }

}

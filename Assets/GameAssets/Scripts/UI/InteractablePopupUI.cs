using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
namespace KMK
{
    public class InteractablePopupUI : MonoBehaviour
    {
        public TextMeshProUGUI interactableText;
        public TextMeshProUGUI itemText;
        public Image icon;

        public void SetInteractableText(string text)
        {
            interactableText.text = text;
        }

        public void SetItemText(string text)
        {
            itemText.text = text;
        }

        public void SetIcon(Sprite sprite)
        {
            icon.sprite = sprite;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    public class CharacterModelChanger : MonoBehaviour
    {
        public List<GameObject> characterModels;

        private void Awake()
        {
            GetAllCharacterModels();
        }
        private void GetAllCharacterModels()
        {
            int childrenGameObject = transform.childCount;

            for (int i = 0; i < childrenGameObject; i++)
            {
                characterModels.Add(transform.GetChild(i).gameObject);
            }
        }

        public void HideAllCharacterModels()
        {
            foreach (GameObject characterModels in characterModels)
            {
                characterModels.SetActive(false);
            }
        }

        public void EnableSpecificCharacter(int index)
        {
            characterModels[index].SetActive(true);
        }

    }
}


using System.Collections;
using System.Collections.Generic;
using KMK;
using UnityEngine;

namespace KMK
{
    public class GameManager : Singleton<GameManager>
    {
        public CanvasGroup fadeScene;
        private float fadeTime = 3.0f;
        IEnumerator FinishGame()
        {
            int interval = 100;
            float intervalFloat = (float)interval;

            for (int i = 0; i < interval; i++)
            {
                fadeScene.alpha += 1 / intervalFloat;

                yield return new WaitForSeconds(fadeTime / intervalFloat);
            }

            fadeScene.alpha = 1;
        
       
        }
        public void HandleGameEndingUI()
        {
            StartCoroutine("FinishGame");
        }
    }
}


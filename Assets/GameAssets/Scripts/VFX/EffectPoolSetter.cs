using System.Collections;
using System.Collections.Generic;
using Redcode.Pools;
using UnityEngine;

namespace  KMK
{
    public class EffectPoolSetter : MonoBehaviour, IPoolObject
    {
        public float effectPlayTime = 3.0f;
        public string effectName;
        public void OnCreatedInPool()
        {
       
        }

        public void OnGettingFromPool()
        {
            StartCoroutine(DisableThisEffect());
        }

        IEnumerator DisableThisEffect()
        {
            yield return new WaitForSeconds(effectPlayTime);
            VFXPoolManager.Instance.RemoveVFX(this);


        }
    }

}

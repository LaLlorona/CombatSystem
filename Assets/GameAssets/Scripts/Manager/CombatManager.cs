using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace KMK
{
    public class CombatManager : Singleton<CombatManager>
    {
        public delegate void CombatEvent();

        public CombatEvent onEvadeSuccess;

        public GameObject hitEffect;

    
        public void DamageObject(GameObject objectToDamage, Attack attack)
        {
            IDamageable[] damageables = objectToDamage.gameObject.GetComponentsInChildren<IDamageable>();
            GameObject effect;
            if (objectToDamage.CompareTag("Enemy"))
            {
                TimeManager.Instance.ChangeTimeScale(0.1f, 0.1f);
                effect = Instantiate(hitEffect, objectToDamage.GetComponent<EnemyManager>().lockOnTransform.position, quaternion.identity);
                Destroy(effect, 2);
                PlayerCameraManager.Instance.DoPlayerCamShake();
            }

            else if (objectToDamage.CompareTag("Player"))
            {
                effect = Instantiate(hitEffect, objectToDamage.transform.position, quaternion.identity);
                Destroy(effect, 2);
                PlayerCameraManager.Instance.DoPlayerCamShake();
            }
            
            

            for (int i = 0; i < damageables.Length; i++ )
            {
                Debug.Log(damageables[i]);
                damageables[i].OnDamage(attack);
            }
        }
        
        public void OnEvadeSuccess()
        {
            onEvadeSuccess?.Invoke();
            
            // TimeManager.Instance.ChangeTimeScale(0.2f, 0.3f);
        }

        
    }

}

using System.Collections;
using System.Collections.Generic;
using KMK;
using UnityEngine;

namespace KMK
{
    public class EnemyAttackBehavior : MonoBehaviour
    {
        public float attackSignSendTime = 0.5f;
        public float attackDurationTime = 0.1f;
        public string visualSignName = "EnemyAttackShine";
        public Transform visualSignPosition;
        public Creature enemyCreature;
        
        // Start is called before the first frame update
        public virtual void SendVisualSignBeforeAttack()
        {
            VFXPoolManager.Instance.PlayVFX(visualSignPosition, visualSignName);
        }
    }

}

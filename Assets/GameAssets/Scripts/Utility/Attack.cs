using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace KMK
{
    public class Attack
    {
        public float damage;
        public float hitDuration;
        public CrowdControl crowdControl;
        public List<Debuff> debuffs;
        public bool isInvokeHitstop = true;

        public Attack (float damage, CrowdControl crowdControl, List<Debuff> debuffs, float hitDuration = 0.25f,bool isInvokeHitstop = true)
        {
            this.damage = damage;
            this.debuffs = debuffs;
            this.crowdControl = crowdControl;
            this.hitDuration = hitDuration;
            this.isInvokeHitstop = isInvokeHitstop;

        }
    }

}

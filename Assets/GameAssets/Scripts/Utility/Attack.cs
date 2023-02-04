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

        public Attack (float damage, CrowdControl crowdControl, float hitDuration = 1f)
        {
            this.damage = damage;
            this.crowdControl = crowdControl;
            this.hitDuration = hitDuration;
        }
    }

}

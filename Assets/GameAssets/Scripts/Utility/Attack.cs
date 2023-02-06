using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace KMK
{
    public class Attack
    {
        public float damage;
        public float hitDuration;
        public List<CrowdControl> crowdControls;

        public Attack (float damage, List<CrowdControl> crowdControls, float hitDuration = 0.25f)
        {
            this.damage = damage;
            this.crowdControls = crowdControls;
            this.hitDuration = hitDuration;
        }
    }

}

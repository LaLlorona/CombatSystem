using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace KMK
{
    public class Attack
    {
        public float damage;
        public CrowdControl crowdControl;

        public Attack (float damage, CrowdControl crowdControl)
        {
            this.damage = damage;
            this.crowdControl = crowdControl;
        }
    }

}

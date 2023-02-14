using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    public class CreatureVFXManager : Singleton<CreatureVFXManager>
    {
        public GameObject stunVfx;
        public GameObject airborneVfx;
        public GameObject grondVfx;


        public GameObject shieldBreakVfx;
        public GameObject slowVfx;

        public void PlayDebuffVfx(Debuff debuff, Transform vfxPosition)
        {
            switch (debuff.debuffType)
            {

                case DebuffType.ShieldBreak:
                    GameObject shieldBreakObject =  Instantiate(shieldBreakVfx, vfxPosition);
                    Destroy(shieldBreakObject, debuff.duration);
                    break;
                case DebuffType.Slow:
                    GameObject slowObject = Instantiate(slowVfx, vfxPosition);
                    Destroy(slowObject, debuff.duration);
                    break;
            }
        }
        
    }
}


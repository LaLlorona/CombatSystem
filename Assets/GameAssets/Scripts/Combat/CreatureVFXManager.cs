using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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

        public GameObject swordVfx;
        public Transform swordVfxPivotPoint;

        public List<EffectAngle> effectAngles;

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

        public void PlayWeaponEffect()
        {
            switch (MainCharacterManager.Instance.currentIndividualCharacterManager.characterWeapon.weaponType)
            {
                case (WeaponType.Sword):
                    GameObject currentSwordVfx = Instantiate(swordVfx, swordVfxPivotPoint.position, Quaternion.identity);
                    currentSwordVfx.transform.eulerAngles = effectAngles[
                        MainCharacterManager.Instance.currentIndividualCharacterManager.characterAnimationEventHandler
                            .attackAnimationIndex].rotation;
                    currentSwordVfx.transform.Rotate(0, swordVfxPivotPoint.rotation.eulerAngles.y, 0, Space.World);
                    Destroy(currentSwordVfx, 1f);
                    
                    
                    break;
                default:
                    break;
            }
        }
        
    }
}

[System.Serializable]
public class EffectAngle
{
 
    public Vector3 rotation;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    public class ProjectileDamageCollider : DamageCollider
    {
        public GameObject impactParticles;
        public GameObject projectileParticles;
        public GameObject muzzleParticles;

        bool hasCollided = false;
        public float destrotyAfter = 10f;

        private float timer = 0.0f;

        private void Start()
        {
            projectileParticles = Instantiate(projectileParticles, transform.position, transform.rotation);
            projectileParticles.transform.parent = transform;

            if (muzzleParticles)
            {
                muzzleParticles = Instantiate(muzzleParticles, transform.position, transform.rotation);
                Destroy(muzzleParticles, 2f);
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Static") || other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                DestroyThisObjectWithEffect();

            }

        }

        private void Update()
        {
            timer += Time.deltaTime;
            if (timer >= destrotyAfter)
            {
                DestroyThisObjectWithEffect();
            }
        }

        private void DestroyThisObjectWithEffect()
        {
            GameObject instantiatedImpactParticles = Instantiate(impactParticles, transform.position, transform.rotation);

            Destroy(projectileParticles);
            Destroy(instantiatedImpactParticles, 5f);
            Destroy(gameObject);
        }
    }

}

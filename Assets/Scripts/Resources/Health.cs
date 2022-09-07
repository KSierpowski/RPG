using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Saving;
using RPG.Stats;
using RPG.Core;

namespace RPG.Resources
{


    public class Health : MonoBehaviour, ISaveable
    {
        [SerializeField] float hP = 100f;

        public bool isDead = false;

        private void Start()
        {
            hP = GetComponent<BaseStats>().GetHealth();
        }


        public bool IsDead()
        {
            return isDead;
        }

        public void TakeDamage(float damage)
        {
            hP = Mathf.Max(hP - damage, 0);
            if (hP == 0)
            {
                Die();

            }
        }

        public float GetPercentage()
        {
            return 100 * (hP / GetComponent<BaseStats>().GetHealth());
        }

        private void Die()
        {
            if (isDead) return;

            isDead = true;

            GetComponent<Animator>().SetTrigger("die");

            GetComponent<ActionScheduler>().CancelCurrentAction();

        }

        public object CaptureState()
        {
            return hP;
        }

        public void RestoreState(object state)
        {
            hP = (float)state;
            if (hP <= 0)
            {
                Die();

            }
        }
    }
}


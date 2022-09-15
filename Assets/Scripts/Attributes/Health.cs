using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Saving;
using RPG.Stats;
using RPG.Core;
using System;
using UnityEngine.Events;

namespace RPG.Attributes
{

    public class Health : MonoBehaviour, ISaveable
    {
        [SerializeField] float regenerationPercentage = 70;
        [SerializeField] UnityEvent<float> takeDamage;

        public class TakeDamageEvent : UnityEvent<float>
        {
        }

        float hP = -1f;

        public bool isDead = false;

        private void Start()
        {
           if(hP < 0f)
            {
                hP = GetComponent<BaseStats>().GetStat(Stat.Health);
            }
            
        }
        private void OnEnable()
        {
            GetComponent<BaseStats>().onlevelUp += RegenerateHealth;
        }
        private void OnDisable()
        {
            GetComponent<BaseStats>().onlevelUp -= RegenerateHealth;
        }

        private void RegenerateHealth()
        {
            float regenHealthPoints = GetComponent<BaseStats>().GetStat(Stat.Health) * (regenerationPercentage/100);
            hP = Mathf.Max(hP, regenHealthPoints);
        }

        public bool IsDead()
        {
            return isDead;
        }

        public void TakeDamage(GameObject instigator, float damage)
        {
            hP = Mathf.Max(hP - damage, 0);

            if (hP == 0)
            {
                Die();
                AwardExperience(instigator);
            }
            else
            {

                takeDamage.Invoke(damage);
            }

            print(damage);
        }

        public float GetHP()
        {
            return hP;
        }

        public float GetMaxHP()
        {
            return GetComponent<BaseStats>().GetStat(Stat.Health);
        }


        private void AwardExperience(GameObject instigator)
        {
            Experience experience = instigator.GetComponent<Experience>();
            if (experience != null)
            {
                experience.GainExperience(GetComponent<BaseStats>().GetStat(Stat.ExperienceReward));
            }
            else return;
        }

        public float GetPercentage()
        {
            return 100 * (hP / GetComponent<BaseStats>().GetStat(Stat.Health));
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


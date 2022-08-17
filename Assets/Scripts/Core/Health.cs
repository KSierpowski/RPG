using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.Core
{


    public class Health : MonoBehaviour
    {
        [SerializeField] float hP = 100f;

        public bool isDead = false;

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

        private void Die()
        {
            if (isDead) return;

            isDead = true;

            GetComponent<Animator>().SetTrigger("die");

            GetComponent<ActionScheduler>().CancelCurrentAction();

        }



    }
}


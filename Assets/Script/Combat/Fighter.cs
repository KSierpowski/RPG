using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] float weaponRange = 2f;

        Transform target;

        private void Update()
        {
            bool isInRange = Vector3.Distance(target.position, transform.position) < weaponRange;
            if (target != null && !isInRange)
            {
                GetComponent<Mover>().MoveTo(target.position);  
            }
            else { GetComponent<Mover>().Stop(); }
        }


        public void Attack(CombatTarget combatTarget)
        { 
            target = combatTarget.transform;
        }










    }

}
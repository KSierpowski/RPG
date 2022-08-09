using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Combat;
using RPG.Core;
namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {

        [SerializeField] float chaseDistance = 5f;

        Fighter fighter;
        GameObject player;
        Health health;

        private void Start()
        {
            fighter = GetComponent<Fighter>();
            player = GameObject.FindWithTag("Player");
            health = GetComponent<Health>();
        }   

        private void Update()
        {
            if (health.IsDead()) return;
            if (InAttackRange() && fighter.CanAttack(player))
            {
                fighter.Attack(player);
            }
            else
            {
                fighter.Cancel();
            }
        }

        private bool InAttackRange()
        {
            float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
            return distanceToPlayer < chaseDistance;

        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }



    }
}
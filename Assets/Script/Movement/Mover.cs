using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Combat;
namespace RPG.Movement

{
    public class Mover : MonoBehaviour
    {
        [SerializeField] Transform target;

        NavMeshAgent player;


        private void Start()
        {
            player = GetComponent<NavMeshAgent>();
        }
        void Update()
        {

            UpdateAnimation();

        }

        public void StartMoveAction(Vector3 destination)
        {
            GetComponent<Fighter>().Cancel();
            MoveTo(destination);
        }


        public void MoveTo(Vector3 destination)
        {
            player.destination = destination;
            player.isStopped = false;
        }

        public void Stop()
        {
            player.isStopped = true;
        }


        public void UpdateAnimation()
        {
            Vector3 velocity = player.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }
    }
}
       

       


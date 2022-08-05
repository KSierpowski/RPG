using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Core;

namespace RPG.Movement

{
    public class Mover : MonoBehaviour, IAction
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
            GetComponent<ActionScheduler>().StartAction(this);
            MoveTo(destination);
        }


        public void MoveTo(Vector3 destination)
        {
            player.destination = destination;
            player.isStopped = false;
        }

        public void Cancel()
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
       

       


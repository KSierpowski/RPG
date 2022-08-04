using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 
namespace RPG.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] Transform target;

        NavMeshAgent player;

        void Update()
        {

            UpdateAnimation();

        }
        private void Start()
        {
            player = GetComponent<NavMeshAgent>();
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
       

       


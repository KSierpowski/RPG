using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.Combat
{


public class EnemyHealth : MonoBehaviour
{
       [SerializeField] float health = 100f;

        public void TakeDamage(float damage)
        {
            health = Mathf.Max(health- damage, 0);
            print(health);
            if(health <= 0)
            {
                print("dead");
                Destroy(gameObject);
            }
        }









}
}
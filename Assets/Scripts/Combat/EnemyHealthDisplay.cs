using RPG.Resources;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Combat
{
    public class EnemyHealthDisplay : MonoBehaviour
    {
        Fighter fighter;
        
        private void Awake()
        {
            fighter = GameObject.FindWithTag("Player").GetComponent<Fighter>();
        }

        private void Update()
        {
            if (fighter.GetTarget() != null)
            {
                Health health = fighter.GetTarget();
                GetComponent<Text>().text = String.Format("{0:0}/{1:0}", health.GetHP(), health.GetMaxHP());
            }
            else { GetComponent<Text>().text = "N/A"; return; }
        }
    }
}

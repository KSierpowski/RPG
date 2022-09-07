using RPG.Stats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Resources
{
    public class Experience : MonoBehaviour
    {
        [SerializeField] float experiencePoints = 0;
        BaseStats exp;

        public void GainExperience(float experience)
        {
            experiencePoints += experience;
        }
    }

}
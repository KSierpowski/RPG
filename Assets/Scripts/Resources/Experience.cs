using RPG.Saving;
using RPG.Stats;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Stats
{
    public class Experience : MonoBehaviour, ISaveable

    {
        [SerializeField] float experiencePoints = 0;
        

        public void GainExperience(float experience)
        {
            experiencePoints += experience;
        }
        public float GetPoints()
        {
            return experiencePoints;
        }

        public object CaptureState()
        {
            return experiencePoints;
        }



        public void RestoreState(object state)
        {
            experiencePoints = (float)state;
        }


    }

}
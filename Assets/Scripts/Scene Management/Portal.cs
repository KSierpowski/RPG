using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

namespace RPG.SceneManagement
{
    public class Portal : MonoBehaviour
    {


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                int nextSceneIndex = currentSceneIndex + 1;
                if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
                {
                    nextSceneIndex = 0;
                }
                SceneManager.LoadScene(nextSceneIndex);
            }
        }
    }
}

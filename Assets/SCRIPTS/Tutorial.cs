using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    private bool WatchTutorial = false;
   public void TutorialScene()
    {
        if(!WatchTutorial && SceneHandler.count !=1)
        {
            SceneManager.LoadScene("Tutorial");
            WatchTutorial = true;
        }
       
    }
}

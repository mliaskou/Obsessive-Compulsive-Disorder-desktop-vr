using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public static SceneHandler Instance;

    public List<string> SceneHistory = new List<string>();
    public static int count = 0;
    public GameObject nar;
  
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;//Avoid doing anything else
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);

    }

    public void SaveScene()
    {

        Scene activeScene = SceneManager.GetActiveScene();
        SceneHistory.Add(activeScene.name);

        GameStateManager script = GameObject.FindObjectOfType<GameStateManager>();
        if (activeScene.name == "Entry")
        {
            Debug.Log("Entry");

            count++;
            if (count >= 2)
            {
                script.Resume();
                GameObject.FindGameObjectWithTag("button").SetActive(false);

            }
            if (count >= 6)
            {
                nar.SetActive(true);
            }
        }

    }

}



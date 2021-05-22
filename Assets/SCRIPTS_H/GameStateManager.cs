using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GameStateManager : MonoBehaviour
{
    public FirstPersonController fps;
    public static bool isPaused = false;
    public GameObject Time;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
  
        
    }

    public void Pause()
    {
        Time.SetActive(false);
        fps.enabled = false;

        // Show cursor
        fps.ToggleLockCursor(false);
        Cursor.visible = true;

        isPaused = true;
      
    }


    public void Resume()
    {
        print("Resuming");
        Time.SetActive(true);
        fps.enabled = true;
        Cursor.visible = false;
        isPaused = false;
        
    }
}

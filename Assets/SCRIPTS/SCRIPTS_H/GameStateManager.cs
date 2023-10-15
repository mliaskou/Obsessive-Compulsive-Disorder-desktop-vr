using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GameStateManager : MonoBehaviour
{
    public FirstPersonController fps;
    public static bool isPaused = false;
    public GameObject Time;

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

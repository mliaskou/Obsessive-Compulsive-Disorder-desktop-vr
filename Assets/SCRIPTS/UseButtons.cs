using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UseButtons : MonoBehaviour
{
    public FirstPersonController fps;
   
    // Start is called before the first frame update
    void Start()
    {
        Panel();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Panel ()
    {
        fps.enabled = false;
        fps.ToggleLockCursor(false);
        Cursor.visible = true;
        
    }

    public void Resume()
    {
        fps.enabled = true;
        fps.ToggleLockCursor(true);
        Cursor.visible = false;
       
    }
    
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

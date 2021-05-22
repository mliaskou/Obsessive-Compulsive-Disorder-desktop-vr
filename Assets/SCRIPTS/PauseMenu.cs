using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject Time;
    public GameObject FPSController;
    [SerializeField] public MouseLook m_MouseLook;


    // Start is called before the first frame update
    void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    { if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
    }

   public void Resume ()
    {
        Debug.Log("Resume");
        pauseMenuUI.SetActive(false);
        Time.SetActive(true);
        GameIsPaused = false;
        GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = true;
        Cursor.visible = false;


    }

    void Pause ()
    {
        Cursor.visible = true;
        GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = false;
        pauseMenuUI.SetActive(true);
        Time.SetActive(false);
        GameIsPaused = true;
        




    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}

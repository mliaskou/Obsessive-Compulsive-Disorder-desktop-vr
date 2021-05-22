using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UITextManager : MonoBehaviour
{

    public FirstPersonController playerl;
    public GameStateManager gsm;
    public GameObject textWindow;
    public Text textField;
    private string label;

    public GameObject pauseMenuUI;
    public GameObject Time;


    string initialText = "Έχω κανονίσει να βγω σε 10 λεπτά. Χρειάζεται να μαζέψω τα πράγματα από το πάτωμα πριν βγω.";
    string taskText1 = "Για να μην κολλήσω μικρόβια από τα αντικείμενα, χρειάζεται να πλύνω τα χέρια μου χ φορές.";
    string taskText2 = "LOREM IPSUM";

    private void Awake()
    {
        
       
    }
    // Start is called before the first frame update
    void Start()
    {

        SceneHandler scene = GameObject.FindObjectOfType<SceneHandler>();
        gsm.Pause();
        scene.SaveScene();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GameStateManager.isPaused)
            {
               
                pauseMenuUI.SetActive(false);
                gsm.Resume();

            }
            else
            {
               
                pauseMenuUI.SetActive(true);
                gsm.Pause();
             
            }
        }
    }

    public void OpenTextWindow()
    {
        textWindow.SetActive(true);
        gsm.Pause();

    }

    public void CloseTextWindow()
    {
        textWindow.SetActive(false);
        gsm.Resume();


    }

    public void ClosePauseMenuWindow()
    {
        print("Closing");
        pauseMenuUI.SetActive(false);
        gsm.Resume();
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

    public void UpdateTextField(string newText)
    {
        textField.text = newText;
    }

   

}

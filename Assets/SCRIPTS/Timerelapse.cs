using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timerelapse : MonoBehaviour
{
    float timeElapsed;
    public float timeRemaining = 600f;
    public bool timerIsRunning = false;
    public Text timeText;

    public Slider SliderColor;
    public Image timeSliderForeground;

    public Color sliderFullColour = Color.green;
    public Color sliderEmptyColour = Color.red;
    public GameObject Slider;
    public static bool isOpen;
    
    public UITextManager textManager;
    public string txt;
    public string txt1;
 

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        Slider.SetActive(false);

    }

    public void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);

                if (isOpen == true)
                {
                    Slider.SetActive(true);
                    timeElapsed = Mathf.Clamp(timeElapsed, 0, timeRemaining);

                    float timeRemainingNormalized = timeElapsed / timeRemaining;
                    SliderColor.value = timeRemainingNormalized;


                    if (timeElapsed < timeRemaining)
                    {
                        Color SliderColor = Color.Lerp(sliderEmptyColour, sliderFullColour, timeRemainingNormalized);
                        timeElapsed += Time.deltaTime;

                    }
                   
                }
                
            }

            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                timeSliderForeground.color = Color.clear;

            }
            void DisplayTime(float timeToDisplay)
            {
                timeToDisplay += 1;

                float minutes = Mathf.FloorToInt(timeToDisplay / 60);
                float seconds = Mathf.FloorToInt(timeToDisplay % 60);

                timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
        }


    }
   
}
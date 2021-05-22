using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    public static PlayerProperties Instance;
    public bool[] pagePickedUp = new bool[5] { false, false, false, false, false };
    public bool[] DoorIsOpen = new bool[5] { false, false, false, false, false };
    public bool[] HasEntered = new bool[5] { false, false, false, false, false };
 
    void Awake()
    {

        // if the singleton hasn't been initialized yet
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;//Avoid doing anything else
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);

    }


    public void PrintBoolArray()
    {
        for (int i = 0; i < pagePickedUp.Length; i++)
        {
            print("Scene " + (i + 1) + ": " + pagePickedUp[i]);
        

        }

    }

    public void DoorOpen()
    {
        for (int i = 0; i < DoorIsOpen.Length; i++)
        {
            print("Scene " + (i + 1) + ": " + DoorIsOpen[i]);
            
        }


    }

    public void HasEnteredtheScene()
    {
        for (int i = 0; i < DoorIsOpen.Length; i++)
        {
            print("Scene " + (i + 1) + ": " + HasEntered[i]);

        }
    }
   
}
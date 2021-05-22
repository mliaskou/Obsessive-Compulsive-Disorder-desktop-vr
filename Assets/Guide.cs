using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour
{

    public static Guide Instance;
    
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

    public void NotStartAgain()
    {
        Debug.Log("Do not show it again");
        


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleTime : MonoBehaviour
{
    public Timerelapse time;
    private bool isTriggered = false;
    public UITextManager textManager;
    public string txt;
    public GameObject Dialogue;
    // Update is called once per frame

    private void Start()
    {
       Timerelapse.isOpen = true;
    }
    public void OnTriggerEnter(Collider other)
    {
        Dialogue.SetActive(true);
        if(!isTriggered)
        {
            isTriggered = true;
            textManager.UpdateTextField(txt);
            textManager.OpenTextWindow();
            
        }
    }
}

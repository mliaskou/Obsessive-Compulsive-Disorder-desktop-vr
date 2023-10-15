using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTr : MonoBehaviour
{

    public static Control control;
    private static bool ShowDialogue = false;
    public DialogueTrigger dialoguetrigger;
    public GameObject Dialogue;
    public AudioSource audiosource;
    private bool isPlaying = false;
    public GameObject monitor;
    void Update()
    {
        if (!isPlaying)
        {
            if (Control.isChecked == true)
            {
                StartCoroutine(AudioPlay());
                monitor.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audiosource.Stop();
            StopAllCoroutines();
            if (Control.isChecked == true)
            {
                if (!ShowDialogue)
                {

                    dialoguetrigger.TriggerDialogue();
                    Dialogue.SetActive(true);
                    ShowDialogue = true;
                }
            }
        }
    }
    IEnumerator AudioPlay()
    {
        yield return new WaitForSeconds(1.5f);
        audiosource.Play();
        isPlaying = true;
    }
}

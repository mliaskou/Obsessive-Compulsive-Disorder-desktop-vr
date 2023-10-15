using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text NameText;
    public Text DialogueText;
    private Queue<string> sentences;
    public Text ContinueButton;
    public GameObject Dialogue;
    public GameObject Time;
    public FirstPersonController fps;
    public static bool isPaused = false;
    public Animator animator;


    public void StartDialogue(Dialogue dialogue)
    {
        
        animator.SetBool("IsOpen", true);
        sentences = new Queue<string>(dialogue.sentences);
        HandleClick();
        NameText.text = dialogue.name;
        Time.SetActive(false);
        fps.enabled = false;
        fps.ToggleLockCursor(false);
        Cursor.visible = true;
       
    }

    public void HandleClick()
    {
        if(sentences.Count == 0)
        {
            Dialogue.SetActive(false);
            Time.SetActive(true);
            fps.enabled = true;
            
        
            Cursor.visible = false;
            animator.SetBool("IsOpen", false);
            isPaused = true;
          
            return;
        }
        else if(sentences.Count == 1)
        {
            ContinueButton.text = "Close";
            
        }
        else
        { 
            ContinueButton.text = "Continue";  
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }   

    IEnumerator TypeSentence( string sentence)
    {
        DialogueText.text = "";
        foreach( char letter in sentence.ToCharArray())
        {
            DialogueText.text += letter;
            yield return null;
        }
    }
}

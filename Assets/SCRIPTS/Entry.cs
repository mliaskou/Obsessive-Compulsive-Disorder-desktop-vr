using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Entry : MonoBehaviour, IInteractable
{
    [SerializeField] private string label;
    public int number = 0;
    public AudioSource dooraudio;

    public string Label
    {
        get { return label; }
    }
    public enum EffectiveRangeMode
    {
        Distance, Trigger
    }

    public EffectiveRangeMode rangeMode = EffectiveRangeMode.Distance;
    [Range(0.1f, 10)] public float effectiveRange;

   
    public void Start()
    {
        dooraudio = GetComponent<AudioSource>();
    }
   

    public void Interact(CharacterEntity entity)
    {
        if (rangeMode == EffectiveRangeMode.Distance)
        {
            float d = Vector3.Distance(transform.position, entity.transform.position);
            if (d > effectiveRange) return;
        }
        print("Interacted with " + entity.name);
        PlayerProperties pp = GameObject.FindObjectOfType<PlayerProperties>();
        dooraudio.Play();
        dooraudio.volume = 0.15f;
        if ( label == "Στάδιο1" && pp.HasEntered[number - 1] == false)
        {
            SceneManager.LoadScene("Στάδιο1");
            pp.HasEntered[number - 1] = true;
            
        }
        if(label == "Στάδιο2" && pp.HasEntered[number - 1] == false)
        {
            SceneManager.LoadScene("Στάδιο2");
            pp.HasEntered[number - 1] = true;
        }
       if (label == "Στάδιο3" && pp.HasEntered[number - 1] == false)
        {
            SceneManager.LoadScene("Στάδιο3");
            pp.HasEntered[number - 1] = true;
        }
        if (label == "Στάδιο4" && pp.HasEntered[number - 1] == false)
        {
            SceneManager.LoadScene("Στάδιο4");
            pp.HasEntered[number - 1] = true;
        }
        if (label == "Στάδιο5" && pp.HasEntered[number-1]==false)
        {
            SceneManager.LoadScene("Στάδιο5" );
            pp.HasEntered[number - 1] = true;
        }
    }
    public string GetTextLabel()
    {
        return label;
    }

    public bool IsInteractionAllowed(CharacterEntity entity)
    {
        float d = Vector3.Distance(transform.position, entity.transform.position);
        return d <= effectiveRange;

    }
}

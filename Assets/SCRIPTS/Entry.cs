using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Entry : MonoBehaviour, IInteractable
{
    [SerializeField] private string label;
    public int number = 0;
    public AudioSource audio;

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
       audio = GetComponent<AudioSource>();
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
        audio.Play();
        audio.volume = 0.15f;

        if (label !=null && pp.HasEntered[number - 1] == false)//Load scene if not already visited
        {
            SceneManager.LoadScene(label);
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

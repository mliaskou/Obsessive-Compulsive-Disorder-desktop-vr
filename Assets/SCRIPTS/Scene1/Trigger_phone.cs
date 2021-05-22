using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;
using UnityEngine.UI;


public class Trigger_phone : MonoBehaviour, IInteractable
{

    public static Trigger trigger;
    public static int numberOfTriggers;
    public DialogueTrigger dialoguetrigger;
    public GameObject Dialogue;
    public AudioSource phone;
    bool isPlaying = false;
    bool ShowDialogue = false;
    public GameObject Diary;

    [SerializeField] private string label;

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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Trigger.isTriggered)
        {
            if (!isPlaying)
            {
                phone.Play();
                phone.volume = 0.2f;
                isPlaying = true;
            }
        }
    }

    public void Interact(CharacterEntity entity)
    {
        if (rangeMode == EffectiveRangeMode.Distance)
        {
            float d = Vector3.Distance(transform.position, entity.transform.position);
            if (d > effectiveRange) return;
        }
        print("Interacted with " + entity.name);

        phone.Stop();
        if (Trigger.isTriggered)
        {
            if (!ShowDialogue)
            {
                dialoguetrigger.TriggerDialogue();
                Dialogue.SetActive(true);
                ShowDialogue = true;
                Diary.SetActive(true);
            }

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger5 : MonoBehaviour, IInteractable
{

    public DialogueTrigger dialoguetrigger;
    public GameObject Dialogue;
    private bool AlreadyTriggered = false;

    public GameObject DiaryPage;


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


    public void Interact(CharacterEntity entity)
    {
        if (rangeMode == EffectiveRangeMode.Distance)
        {
            float d = Vector3.Distance(transform.position, entity.transform.position);
            if (d > effectiveRange) return;
        }
        print("Interacted with " + entity.name);

        if (!AlreadyTriggered && Scene5_item.IsCollected == true)
        {
            dialoguetrigger.TriggerDialogue();
            Dialogue.SetActive(true);
            AlreadyTriggered = true;
            DiaryPage.SetActive(true);

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

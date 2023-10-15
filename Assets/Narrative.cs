using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Narrative : MonoBehaviour, IInteractable
{

    public DialogueTrigger dialoguetrigger;
    public static bool isOpen = false;

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

        dialoguetrigger.TriggerDialogue();
        isOpen = true;
        GameObject.FindGameObjectWithTag("obstacle").SetActive(false);
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

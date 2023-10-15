using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class TriggerDialogue2 : MonoBehaviour, IInteractable
{
    [SerializeField] private string label;

    public DialogueTrigger dialoguetrigger;
    public GameObject DialogueButton;
    public FirstPersonController fps;
    private bool AlreadyTriggered;

    public GameObject DiaryPage;

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
        AlreadyTriggered = false;
    }

    public void Interact(CharacterEntity entity)
    {
        if (rangeMode == EffectiveRangeMode.Distance)
        {
            float d = Vector3.Distance(transform.position, entity.transform.position);
            if (d > effectiveRange) return;
        }
        print("Interacted with " + entity.name);

        if(!AlreadyTriggered)
        {
            fps.enabled = false;
            Cursor.visible = true;
            DialogueButton.SetActive(true);
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

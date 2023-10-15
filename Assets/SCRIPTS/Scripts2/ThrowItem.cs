using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowItem : MonoBehaviour, IInteractable
{
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
    public UITextManager textManager;
    public string txt;
    public Text ItemText;
    public string ItemTextLabel = "Items: ";
    public GameObject dialogue;
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Interact(CharacterEntity entity)
    {
        if (rangeMode == EffectiveRangeMode.Distance)
        {
            float d = Vector3.Distance(transform.position, entity.transform.position);
            if (d > effectiveRange) return;
        }
        print("Interacted with " + entity.name);

        if( Control3.IsCollected ==true)
        {
            textManager.UpdateTextField(txt);
            textManager.OpenTextWindow();
            Timerelapse.isOpen = false;
            Control3.Item--;
            ItemText.text = ItemTextLabel + Control3.Item.ToString();
            dialogue.SetActive(true);
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

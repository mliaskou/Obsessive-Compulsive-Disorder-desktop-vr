using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control3 : MonoBehaviour, IInteractable
{
    public static int Item = 0;
    public int AllItems = 3;
    public Text ItemText;
    public string ItemTextLabel = "Items: ";

    public string txt;
    public UITextManager textManager;
    public Timerelapse time;
    public static bool IsCollected;

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


    void Start()
    {
        textManager = GameObject.FindObjectOfType<UITextManager>();
        Timerelapse.isOpen = false;
        IsCollected = false;
    }

    public void Interact(CharacterEntity entity)
    {
        if (rangeMode == EffectiveRangeMode.Distance)
        {
            float d = Vector3.Distance(transform.position, entity.transform.position);
            if (d > effectiveRange) return;
        }
        print("Interacted with " + entity.name);
        
            Destroy(gameObject);
            Item++;
            ItemText.text = ItemTextLabel + Item.ToString();
        
        if (gameObject.CompareTag("scissors") && IsCollected == false)
        {
            textManager.UpdateTextField(txt);
            textManager.OpenTextWindow();
            Timerelapse.isOpen = true;
            IsCollected = true;
            
            
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

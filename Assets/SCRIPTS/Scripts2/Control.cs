using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour, IInteractable
{
    [SerializeField] private string label;

    public UITextManager textManager;
    public string txt;
    public Text CheckText;
    private int Check = 0;
    public static bool isChecked = false;
    private bool isPlaying = false;
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
        Timerelapse.isOpen = true;
        
    }

    public void Interact(CharacterEntity entity)
    {
        if (rangeMode == EffectiveRangeMode.Distance)
        {
            float d = Vector3.Distance(transform.position, entity.transform.position);
            if (d > effectiveRange) return;
        }
        print("Interacted with " + entity.name);
        Check = Check + 1;
        CheckText.text = "Έλεγχος:" + Check;
        if (Check >= 1 && Check <= 3)
        {
            textManager.UpdateTextField(txt);
            textManager.OpenTextWindow();
            Timerelapse.isOpen = false;
            isChecked = true;
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

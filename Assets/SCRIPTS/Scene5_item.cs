using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene5_item : MonoBehaviour, IInteractable
{

    public static int Item = 0;
    public int AllItems = 3;
    public Text ItemText;
    public string ItemTextLabel = "Items: ";

    public string txt;
    public UITextManager textManager;
    public Timerelapse time;
    public static bool IsCollected;
    public GameObject Dialogue;
    public AudioManager audioManager;

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
        Timerelapse.isOpen = true;
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

        audioManager.SearchTheAudio("pickitem");
        Item++;
        ItemText.text = ItemTextLabel + Item.ToString();
        Destroy(gameObject);
        if (Item >= AllItems)
        {

            Timerelapse.isOpen = false;

            IsCollected = true;
            if (time.timerIsRunning == true)
            {
                textManager.UpdateTextField(txt);
                textManager.OpenTextWindow();
            }
            Dialogue.SetActive(true);
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

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Items : MonoBehaviour, IInteractable
{
    [SerializeField] private string label;
    private static int Item = 0;
    private int sinkTriggers = 0;
    public int totalSinkTriggers = 4;
    public int AllItems;
    public Text numberText;
    public string ItemTextLabel = "Items: ";
    public string numberTextLabel = "Πλύσιμο χεριών: ";
    public static bool isCollected = false;
    public Timerelapse time;
    public GameObject dialogue;
    public Dialogue dialoguePanel;
    public GameObject diary;
    public string txt = "Για να μην κολλήσω μικρόβια χρειάζεται να πλύνω τα χέρια μου 2 φορές";
    public UITextManager textManager;
    public AudioManager audioManager;
    public FirstPersonController fps;

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
        isCollected = false;
    }


    public void Interact(CharacterEntity entity)
    {
        if (rangeMode == EffectiveRangeMode.Distance)
        {
            float d = Vector3.Distance(transform.position, entity.transform.position);


            if (d > effectiveRange) return;
        }
        CheckTheInteraction();
    }

    public void CheckTheInteraction()
    {
        if (Label == "Πρέπει να το μαζέψω")
        {
            Item += 1;
            numberText.text = ItemTextLabel + Item.ToString();

            audioManager.SearchTheAudio("pickitem");
            Destroy(gameObject);

            if (Item >= AllItems)
            {
                Timerelapse.isOpen = true;
                textManager.UpdateTextField(txt);
                textManager.OpenTextWindow();
                isCollected = true;
                Debug.Log(isCollected);
            }
        }

        if (Label == "Πρέπει να πλύνω τα χέρια μου" && isCollected == true)
        {
            sinkTriggers++;
            audioManager.SearchTheAudio("sink");
            numberText.text = numberTextLabel + "  " + sinkTriggers.ToString();

            if (sinkTriggers >= totalSinkTriggers)
            {
                Timerelapse.isOpen = false;
                textManager.UpdateTextField(txt);
                textManager.OpenTextWindow();
                audioManager.SearchTheAudio("phone");
            }

        }
        if (Label == "Τηλέφωνο" && isCollected == true)
        {
            dialogue.SetActive(true);
            diary.SetActive(true);
            fps.enabled = false;
            Cursor.visible = true;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger : MonoBehaviour, IInteractable
{
    //public GameObject Text;
    public int numberOfTriggers = 5;
    public string txt;
    public static int number = 0;
    public Timerelapse time;
    public UITextManager textManager;
    public Text NumberText;
    public string NumberTextLabel = "Πλύσιμο χεριών:";

    public static Items allitems;
    public static bool isTriggered;
    public AudioSource audioclip;

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

    private void Start()
    {
        //Text.SetActive(false);
        textManager = GameObject.FindObjectOfType<UITextManager>();
        isTriggered = false;
        audioclip = GetComponent<AudioSource>();
    }

    public void Interact(CharacterEntity entity)
    {
        if (rangeMode == EffectiveRangeMode.Distance)
        {
            float d = Vector3.Distance(transform.position, entity.transform.position);
            if (d > effectiveRange) return;
        }
        print("Interacted with " + entity.name);
        if ( Items.isCollected)
        {
            audioclip.Play();
            audioclip.volume = 0.15f;
            number += 1;
            NumberText.text = NumberTextLabel + number.ToString();
            Debug.Log(NumberTextLabel + number);
        }
        if (number >= numberOfTriggers)
        {
            //Text.SetActive(true);
            Timerelapse.isOpen = false;
            textManager.UpdateTextField(txt);
            textManager.OpenTextWindow();
            isTriggered = true;
            
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



   


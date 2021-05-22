using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour, IInteractable
{
    [SerializeField] private string label;
    public static int Item = 0;
    public int AllItems ;
    public Text ItemText;
    public string ItemTextLabel = "Items: ";
    public static bool isCollected = false;
    public Timerelapse time;
    
    public string txt= "Για να μην κολλήσω μικρόβια χρειάζεται να πλύνω τα χέρια μου 2 φορές";
    public UITextManager textManager;
    public AudioSource sound;

    

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
        print("Interacted with " + entity.name);
        
        sound.Play();
        sound.volume = 0.15f;
        Item++;
        ItemText.text = ItemTextLabel + Item.ToString();
        Destroy(gameObject);
        Debug.Log("Items:" + Item);
        if (Item >= AllItems)
        {
            Timerelapse.isOpen = true;
            textManager.UpdateTextField(txt);
            textManager.OpenTextWindow();
            isCollected = true;

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

   

    /* void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Destroy(gameObject);
                

                Debug.Log("Items:" + Item);

                if (Item >= AllItems)
                {
                    Timerelapse.isOpen = true;
                    textManager.UpdateTextField(txt);
                    textManager.OpenTextWindow();
                    isCollected = true;

                }

            }
        }*/


}

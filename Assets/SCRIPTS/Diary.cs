using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diary : MonoBehaviour, IInteractable
{
    public int sceneNumber = 0;
    [SerializeField] private string label;
    public static bool DiaryPageisDestroyed;
    public GameObject dialogue;
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

        PlayerProperties pp = GameObject.FindObjectOfType<PlayerProperties>();
        InventoryUI inventory = GameObject.FindObjectOfType<InventoryUI>();

        sound.Play();
        sound.volume = 0.15f;
        pp.pagePickedUp[sceneNumber - 1] = true; 

        inventory.Slots[sceneNumber - 1].SetActive(true);
        DiaryPageisDestroyed = true;
     
        pp.PrintBoolArray();
        
       
        Destroy(gameObject);
        dialogue.SetActive(false);
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

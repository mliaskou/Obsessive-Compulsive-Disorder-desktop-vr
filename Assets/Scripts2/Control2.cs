using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control2 : MonoBehaviour, IInteractable
{
    [SerializeField] private string label;

    public UITextManager textManager;
    public string txt;
    public string txt1;
    public string txt2;
    public Text CheckText;
    private int Check = 0;
    public static bool isRechecked = false;
    public GameObject thought;
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
        Check = Check + 1;
        CheckText.text = "Έλεγχος:" + Check;
        if (Check == 1)
        {
            textManager.UpdateTextField(txt);
            textManager.OpenTextWindow();
            Timerelapse.isOpen = false;
            Recheck();
            
        }
        if (Check >= 2)
        {
            textManager.UpdateTextField(txt2);
            textManager.OpenTextWindow();
            Timerelapse.isOpen = false;
            thought.SetActive(true);
        }
    }

    void Recheck()
    {
            StartCoroutine(Wait());
        
    }
    public IEnumerator Wait()
    {
        if (Check == 1 && isRechecked ==false)
        {
            yield return new WaitForSeconds(5f);
            textManager.UpdateTextField(txt1);
            textManager.OpenTextWindow();
            Timerelapse.isOpen = true;
            isRechecked = true;
        }
        else StopAllCoroutines();
        yield return null;
       
       
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

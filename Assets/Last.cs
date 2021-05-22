using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;
using System.Linq;

public class Last : MonoBehaviour, IInteractable
{
    [SerializeField] private string label;
    public static Narrative nar;
    public AudioSource sound;
    public static bool[] end = new bool[5] { false, false, false, false, false };
    public GameObject panel;
    public int number;
    public FirstPersonController fps;
    private bool isAllTrue = false;


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
        nar = GameObject.FindObjectOfType<Narrative>();
        sound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        foreach (bool b in end)
        {
            if (b)
            {
                isAllTrue = true;
                
            }
            else
            {
                isAllTrue = false;
                break;
            }
        }

        if(isAllTrue == true)
        {
            StartCoroutine(GameOver());
        }
    }

    public void Interact(CharacterEntity entity)
    {
        if (rangeMode == EffectiveRangeMode.Distance)
        {
            float d = Vector3.Distance(transform.position, entity.transform.position);
            if (d > effectiveRange) return;
        }
        print("Interacted with " + entity.name);

        if (Narrative.isOpen == true)
        {
            sound.Play();
            sound.volume = 0.15f;
            end[number - 1] = true;
            GameEnds();

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

    void GameEnds()
    {

        for (int i = 0; i < end.Length; i++)
        {
            print(end[i]);
            /* if (end[0] == true && end[1] == true && end[2] == true && end[3] == true && end[4] == true)
             {

                 StartCoroutine(GameOver());

             }*/
        }
    }
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(28f);
        fps.enabled = false;
        fps.ToggleLockCursor(false);
        Cursor.visible = true;
        panel.SetActive(true);


    }

}


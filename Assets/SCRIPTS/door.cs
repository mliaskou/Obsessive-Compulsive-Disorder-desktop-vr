using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;


public class door : MonoBehaviour, IInteractable
{
    Animator anim;
    public Collider doorCollider;
    public int sceneNumber = 0;
    public AudioSource audiodoor;



    private void Start()
    {
        anim = GameObject.Find("door.005").GetComponent<Animator>();
        doorCollider = GetComponent<Collider>();
        doorCollider.isTrigger = false;
        audiodoor = GetComponent<AudioSource>();

    }

    private void Update()
    {


    }


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

    // Start is called before the first frame update


    public void Interact(CharacterEntity entity)
    {
        if (rangeMode == EffectiveRangeMode.Distance)
        {
            float d = Vector3.Distance(transform.position, entity.transform.position);
            if (d > effectiveRange) return;
        }


        if (Diary.DiaryPageisDestroyed == true)
        {
            PlayerProperties pp = GameObject.FindObjectOfType<PlayerProperties>();
            pp.DoorIsOpen[sceneNumber - 1] = true;
            if (pp.DoorIsOpen.SequenceEqual(pp.pagePickedUp))
            {
                
                StartCoroutine(Entry());
                doorCollider.isTrigger = true;
                audiodoor.Play();
                audiodoor.volume = 0.15f;
                anim.SetBool("IsWalking", true);
            }

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


    public IEnumerator Entry()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Entry");
    }
    void PauseAnimationEvent()
    {
        anim.enabled = false;

    }


}


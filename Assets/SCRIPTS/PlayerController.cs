using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : CharacterEntity
{
    Ray ray;
    RaycastHit hit = new RaycastHit();
    bool sphereCast;
    
    Text interactableText;

    // Start is called before the first frame update
    void Start()
    {
        interactableText = GameObject.Find("InteractableIext").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            if (sphereCast)
            {
                IInteractable interactable = hit.transform.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.Interact(this);
                   
                }
            }

        }
    }

    void FixedUpdate()
    {
        ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        sphereCast = Physics.SphereCast(ray, 0.15f, out hit);
        if (sphereCast)
        {
            IInteractable interactable = hit.transform.GetComponent<IInteractable>();
            if (interactable != null && interactable.IsInteractionAllowed(this))
            {
                interactableText.text = interactable.GetTextLabel();
            }
            else interactableText.text = null;
        }
        else
        {
            interactableText.text = null;
        }
    }
}

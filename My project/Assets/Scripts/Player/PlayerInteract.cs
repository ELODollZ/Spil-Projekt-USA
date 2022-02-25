using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//af rasmus
// scriptet giver spilleren mulighed for at interagere med objekter sålænge de har interfacen IInteractable

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    float interactDistance = 4f;

    [SerializeField]
    Transform interactText;

    [SerializeField]
    Vector2 textOffset;

    // Update is called once per frame
    void Update()
    {
        IInteractable interactObj = InteractObj();

        if (interactObj != null)
        {
            interactText.gameObject.SetActive(true);
            interactText.position = interactObj.position + textOffset;
            if (Input.GetKeyDown(KeyCode.E))
            {
                interactObj.Interact();
            }
        }
        else
        {
            interactText.gameObject.SetActive(false);
        }
    }

    //finder Interactable objekter i en radius af spillern, hvis der er mere end en bliver den nærmeste valgt
    private IInteractable InteractObj()
    {
        //finder ting der kan intergeresmed
        List<IInteractable> interactables = new List<IInteractable>();
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, interactDistance);
        for (int i = 0; i < hits.Length; i++)
        {
            IInteractable interactable = hits[i].GetComponentInParent<IInteractable>();
            if (interactable == null) hits[i].GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactables.Add(interactable);
            }
        }
        //stopper hvis der ikke blev fundet noget der kan interaers med
        if (interactables.Count == 0) return null;

        //finder den ting der er tetest på
        IInteractable closest = interactables[0];
        for (int i = 1; i < interactables.Count; i++)
        {
            if (Vector2.Distance(interactables[i].position, transform.position) < Vector2.Distance(closest.position, transform.position))
            {
                closest = interactables[i];
            }
        }
        return closest;
    }
}

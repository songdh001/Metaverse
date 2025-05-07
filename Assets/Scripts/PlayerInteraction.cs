using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactRange = 1f;
    public LayerMask interactableLayer;
    private Collider2D currentTarget;



    // Update is called once per frame
    void Update()
    {
        DetectInteractable();

        if (currentTarget != null && Input.GetKeyDown(KeyCode.E))
        {
            currentTarget.GetComponent<IInteractable>()?.Interact();
        }
    }

    void DetectInteractable()
    {
        currentTarget = Physics2D.OverlapCircle(transform.position, interactRange, interactableLayer);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Saisir : MonoBehaviour
{
    [SerializeField] private bool droite = false;
    private XRBaseInteractor interactor;
    private XRGrabInteractable closestItem;
    private XRGrabInteractable interactingItem;
    private HashSet<XRGrabInteractable> objectsHoveringOver = new HashSet<XRGrabInteractable>();

    private IXRSelectInteractor xrInteractor;
    private IXRSelectInteractable xrInteractable;


    //Adaption du script Saisir initial avec mise à jour par le XR Interaction Toolkit
    void Start()
    {
        interactor = GetComponent<XRBaseInteractor>();
        if (interactor == null)
        {
            Debug.LogError("XRBaseInteractor nécessaire pour ce GO.");
        }
        xrInteractor = interactor as IXRSelectInteractor;
        xrInteractable = interactingItem as IXRSelectInteractable;
    }

    private void OnTriggerEnter(Collider other)
    {
        var interactable = other.GetComponent<XRGrabInteractable>();
        if (interactable != null && !objectsHoveringOver.Contains(interactable))
        {
            objectsHoveringOver.Add(interactable);
            UpdateClosestItem(interactable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var interactable = other.GetComponent<XRGrabInteractable>();
        if (interactable != null)
        {
            objectsHoveringOver.Remove(interactable);

            if (interactable == closestItem)
            {
                closestItem = null;
                FindClosestItem();
            }
        }
    }

    void Update()
    {
        if (closestItem != null && interactingItem == null && interactor.isSelectActive)
        {
            interactingItem = closestItem;
            interactor.interactionManager.SelectEnter(xrInteractor, xrInteractable);
            Debug.Log($"Item grabbed by {(droite ? "right" : "left")} hand");
        }

        if (interactingItem != null && !interactor.isSelectActive)
        {
            interactor.interactionManager.SelectExit(xrInteractor, xrInteractable);
            interactingItem = null;
            Debug.Log("Item released");
        }
    }

    private void UpdateClosestItem(XRGrabInteractable newInteractable)
    {
        if (closestItem == null ||
            (newInteractable.transform.position - transform.position).sqrMagnitude <
            (closestItem.transform.position - transform.position).sqrMagnitude)
        {
            closestItem = newInteractable;
        }
    }

    private void FindClosestItem()
    {
        float minDistance = float.MaxValue;
        closestItem = null;

        foreach (var item in objectsHoveringOver)
        {
            float distance = (item.transform.position - transform.position).sqrMagnitude;
            if (distance < minDistance)
            {
                minDistance = distance;
                closestItem = item;
            }
        }
    }
}

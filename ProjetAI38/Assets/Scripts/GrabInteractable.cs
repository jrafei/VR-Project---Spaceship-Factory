using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class GrabInteractable : MonoBehaviour
{
    // Référence au contrôleur XR
    private XRController controller;

    // Objet actuellement saisi par le joueur
    private GameObject grabbedObject = null;

    // Initialisation
    void Start()
    {
        // Obtenir le composant XRController attaché à ce GameObject
        controller = GetComponent<XRController>();
    }

    void Update()
    {
        // Vérifie si le bouton de préhension (grip) est appuyé
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool isGrabbing) && isGrabbing)
        {
            if (grabbedObject != null) // Si un objet est à portée et peut être saisi
            {
                // Attache l'objet au contrôleur
                grabbedObject.transform.SetParent(transform);

                // Désactive la physique (empêche que l'objet tombe ou soit affecté par des forces)
                grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
        else if (grabbedObject != null) // Si le bouton de préhension est relâché
        {
            // Détache l'objet du contrôleur
            grabbedObject.transform.SetParent(null);

            // Réactive la physique (pour que l'objet redevienne dynamique)
            grabbedObject.GetComponent<Rigidbody>().isKinematic = false;

            // Libère la référence à l'objet saisi
            grabbedObject = null;
        }
    }

    // Détecte lorsqu'un objet entre dans le champ de collision du contrôleur
    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet a le tag "Grabbable"
        if (other.CompareTag("Grabbable"))
        {
            // Associe l'objet détecté comme étant "grabbedObject"
            grabbedObject = other.gameObject;
        }
    }

    // Détecte lorsqu'un objet sort du champ de collision du contrôleur
    private void OnTriggerExit(Collider other)
    {
        // Si l'objet qui sort est celui que nous avons détecté comme "grabbedObject"
        if (other.gameObject == grabbedObject)
        {
            // Supprime la référence à l'objet
            grabbedObject = null;
        }
    }
}
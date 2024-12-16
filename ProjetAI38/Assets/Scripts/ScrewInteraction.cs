using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;


public class ScrewInteraction : MonoBehaviour
{
    public float screwSpeed = 50f; // Vitesse du vissage
    public float maxScrewDistance = 0.2f; // Distance maximale pour le vissage
    private bool isTouchingScrewdriver = false; // Indique si le tournevis est en contact
    private Transform screwdriverTip; // Référence à l'extrémité du tournevis
    public GameObject ciblePosition; // Position de départ de la vis
    private float screwedAmount = 0f; // Distance totale vissée
    private bool isFullyScrewed = false; // Indique si la vis est entièrement vissée

    private bool button = false;



    // Référence à ton action SteamVR Input
    public SteamVR_Action_Boolean grabGripAction;

    void Start()
    {
        // Initialisation de l'action
        grabGripAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabGrip");

        if (grabGripAction == null)
        {
            Debug.LogError("[GripButtonTest] GrabGrip action not found!");
        }
        else{
            Debug.LogError("[GripButtonTest] GrabGrip action is found!");
        }
    }

    private void Update()
    {
        // Vérifie si le bouton Grip gauche est pressé
        if (grabGripAction != null && grabGripAction.GetState(SteamVR_Input_Sources.LeftHand))
        {
            Debug.Log("Grip gauche est pressé !");
            // Tu peux ajouter ton code ici (ex : déclencher une interaction)
        }
        

        if (grabGripAction != null && grabGripAction.state)
        {
            Debug.Log("Grab APUUYEEEE  !! ");
        }
        // Vérifie si le bouton grab est pressé et que le tournevis est en contact
        if (isTouchingScrewdriver && grabGripAction.state)
        {
            Screw();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fin"))
        {
            isTouchingScrewdriver = true;
            screwdriverTip = other.transform;
            Debug.Log("[ScrewInteraction] Tournevis en contact avec la vis.");
        }
    }



    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Fin"))
        {
            isTouchingScrewdriver = false;
            screwdriverTip = null;
            Debug.Log("[ScrewInteraction] Tournevis hors de contact.");
        }
    }
    public void Screw()
    {
        if (!isFullyScrewed)
        {
            // Calcule la direction pour visser (vers la position cible)
            Vector3 direction = (ciblePosition.transform.position - transform.position).normalized;

            // Déplace la vis vers la position cible
            float step = screwSpeed * Time.deltaTime;
            transform.position += direction * step;

            // Met à jour la distance vissée
            screwedAmount += step;

            // Vérifie si la vis est complètement vissée
            if (screwedAmount >= maxScrewDistance)
            {
                screwedAmount = maxScrewDistance;
                isFullyScrewed = true;
                Debug.Log("[ScrewInteraction] Vis complètement vissée !");
            }
        }
    }
}

/*


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewInteraction : MonoBehaviour
{
    public float screwSpeed = 50f; // Vitesse du vissage
    public float maxScrewDistance = 0.2f; // Distance maximale pour le vissage
    private bool isTouchingScrewdriver = false; // Indique si le tournevis est en contact
    private Transform screwdriverTip; // Référence à l'extrémité du tournevis
    public GameObject ciblePosition; // Position de départ de la vis
    private float screwedAmount = 0f; // Distance totale vissée
    private bool isFullyScrewed = false; // Indique si la vis est entièrement vissée


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("[ScrewInteraction]Collision détectée avec : " + other.gameObject.name);
        //Debug.Log(" Debut de OnTriggerEnter");
        if (other.CompareTag("Fin"))
        {
            Debug.Log("[ScrewInteraction] c est le fin de  ScrewDriver");
            isTouchingScrewdriver = true;
            screwdriverTip = other.transform;
            Screw();
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("[ScrewInteraction] Debut de OnTriggerExit");
        if (other.CompareTag("Fin"))
        {
            isTouchingScrewdriver = false;
            screwdriverTip = null;
        }
    }

    public void Screw()
    {
        Debug.Log("[ScrewInteraction] Debut de Screw");
        if (isTouchingScrewdriver && !isFullyScrewed)
        {
            Debug.Log("[ScrewInteraction] debut de vissage ");
            // Calcule la direction pour visser (vers la position initiale)
            Vector3 direction = (ciblePosition.transform.position - transform.position).normalized;

            // Déplace la vis vers la position cible
            float step = screwSpeed * Time.deltaTime;
            transform.position += direction * step;

            // Met à jour la distance vissée
            screwedAmount += step;

            // Vérifie si la vis est complètement vissée
            if (screwedAmount >= maxScrewDistance)
            {
                screwedAmount = maxScrewDistance;
                isFullyScrewed = true;
                Debug.Log("Vis complètement vissée !");
            }
        }
    }
}
*/
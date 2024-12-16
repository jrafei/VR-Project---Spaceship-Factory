using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;


public class ScrewInteraction : MonoBehaviour
{
    public float screwSpeed = 50f; // Vitesse du vissage
    public float maxScrewDistance = 0.2f; // Distance maximale pour le vissage
    private bool isTouchingScrewdriver = false; // Indique si le tournevis est en contact
    private Transform screwdriverTip; // Référence à l'extrémité du tournevis
    public GameObject ciblePosition; // Position de départ de la vis
    private float screwedAmount = 0f; // Distance totale vissée
    private bool isFullyScrewed = false; // Indique si la vis est entièrement vissée

    //public SteamVR_Action_Boolean grabGripAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabGrip");
    private bool button = false;


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("[ScrewInteraction]Collision détectée avec : " + other.gameObject.name);
        //Debug.Log(" Debut de OnTriggerEnter");
        if (other.CompareTag("Fin"))
        {
            Debug.Log("[ScrewInteraction] c est le fin de  ScrewDriver");
            isTouchingScrewdriver = true;
            screwdriverTip = other.transform;

            if(button){
                Screw();
                button = false;
            }
        }
    }

    protected virtual void HandHoverUpdate(Hand hand){
        GrabTypes startingGrabType = hand.GetGrabStarting();
            if (startingGrabType != GrabTypes.None)
            {
                // Actions exécutées si le bouton "grab" est détecté
                Debug.Log("Bouton grab appuyé !");
                button = true;
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
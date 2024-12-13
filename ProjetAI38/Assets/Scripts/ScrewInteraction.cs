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

    void Start()
    {
        //initialPosition = transform.position; // Enregistre la position de départ de la vis
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Screwdriver"))
        {
            isTouchingScrewdriver = true;
            screwdriverTip = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Screwdriver"))
        {
            isTouchingScrewdriver = false;
            screwdriverTip = null;
        }
    }

    public void Screw()
    {
        if (isTouchingScrewdriver && !isFullyScrewed)
        {
            // Calcule la direction pour visser (vers la position initiale)
            Vector3 direction = (ciblePosition.transform.position - transform.position).normalized;

            // Déplace la vis vers la position initiale
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
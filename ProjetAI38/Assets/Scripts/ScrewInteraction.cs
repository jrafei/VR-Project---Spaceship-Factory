using System.Collections;
using UnityEngine;

public class ScrewInteraction : MonoBehaviour
{
    public float screwSpeed = 50f; // Vitesse du vissage
    public float maxScrewDistance = 0.2f; // Distance maximale pour le vissage
    private bool isTouchingScrewdriver = false; // Indique si le tournevis est en contact
    private Transform screwdriverTip; // Référence à l'extrémité du tournevis
    public GameObject ciblePosition; // Position cible de la vis
    private float screwedAmount = 0f; // Distance totale vissée
    public bool isFullyScrewed = false; // Indique si la vis est entièrement vissée
    private Coroutine screwingCoroutine; // Référence à la coroutine en cours
    private Renderer screwRenderer; // Référence au Renderer de la vis

    void Start()
    {
        // Récupère le Renderer de la vis
        screwRenderer = GetComponent<Renderer>();

        // Vérifie si le Renderer existe
        if (screwRenderer == null)
        {
            Debug.LogError("[ScrewInteraction] Aucun Renderer trouvé sur cet objet !");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("[ScrewInteraction] Collision détectée avec : " + other.gameObject.name);
        if (other.CompareTag("Fin"))
        {
            Debug.Log("[ScrewInteraction] Début de vissage.");
            isTouchingScrewdriver = true;
            screwdriverTip = other.transform;

            // Démarre le vissage progressif
            if (screwingCoroutine == null)
            {
                screwingCoroutine = StartCoroutine(Screw());
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("[ScrewInteraction] Fin de contact avec le tournevis.");
        if (other.CompareTag("Fin"))
        {
            isTouchingScrewdriver = false;

            // Arrête la coroutine de vissage si elle est en cours
            if (screwingCoroutine != null)
            {
                StopCoroutine(screwingCoroutine);
                screwingCoroutine = null;
            }
        }
    }

    private IEnumerator Screw()
    {
        while (!isFullyScrewed && isTouchingScrewdriver)
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

                // Change la couleur du matériau en vert
                if (screwRenderer != null)
                {
                    screwRenderer.material.color = Color.green;
                }
            }

            yield return null; // Attend la prochaine image
        }

        // Arrête la coroutine une fois la vis complètement vissée
        screwingCoroutine = null;
    }
}

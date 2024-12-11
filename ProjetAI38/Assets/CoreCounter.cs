using UnityEngine;
using TMPro; // Nécessaire pour utiliser TextMeshPro

public class CoreCounter : MonoBehaviour
{
    public TextMeshProUGUI counterText; // Référence au champ texte (TextMeshProUGUI pour UI)
    public TextMeshProUGUI statusText; // Référence au champ texte pour afficher "prêt"
    public Transform attachPointL_Wing; // Point d'attache pour l_wing
    public Transform attachPointR_Wing; // Point d'attache pour r_wing
    public Transform attachPointThruster; // Point d'attache pour thruster

    private float counter = 0f; // Compteur
    private bool isReady = false; // Vérifie si le core est prêt

    private MonoBehaviour[] coreScripts; // Liste des scripts MonoBehaviour attachés au Core

    void Start()
    {
        // Initialisation des textes
        if (counterText != null)
            counterText.text = "0.0";

        if (statusText != null)
            statusText.text = "Temps d'assemblage :"; // Pas de message au départ

        // Récupérer tous les scripts MonoBehaviour directement attachés au Core
        coreScripts = GetComponents<MonoBehaviour>();

        // Désactiver tous les scripts sauf ce script
        foreach (var script in coreScripts)
        {
            if (script != this)
                script.enabled = false;
        }
    }

    void Update()
    {
        if (isReady) return; // Arrête le compteur si prêt

        // Incrémente le compteur
        counter += Time.deltaTime;

        // Met à jour le texte du compteur
        if (counterText != null)
            counterText.text = counter.ToString("F1");

        // Vérifie si tous les objets requis sont attachés
        if (IsAllComponentsAttached())
        {
            isReady = true;

            // Affiche "prêt" dans le champ de statut
            if (statusText != null)
                statusText.text = "Prêt";

            // Réactive tous les scripts MonoBehaviour sur le Core
            foreach (var script in coreScripts)
            {
                if (script != this)
                    script.enabled = true;
            }

            Debug.Log("Tous les composants sont attachés. Core prêt.");
        }
    }

    private bool IsAllComponentsAttached()
    {
        // Vérifie si un objet avec le bon tag est enfant des points d'attache
        bool lWingAttached = CheckChildWithTag(attachPointL_Wing, "l_wing");
        bool rWingAttached = CheckChildWithTag(attachPointR_Wing, "r_wing");
        bool thrusterAttached = CheckChildWithTag(attachPointThruster, "thruster");

        return lWingAttached && rWingAttached && thrusterAttached;
    }

    private bool CheckChildWithTag(Transform attachPoint, string requiredTag)
    {
        if (attachPoint == null) return false;

        foreach (Transform child in attachPoint)
        {
            if (child.CompareTag(requiredTag))
            {
                return true;
            }
        }

        return false;
    }
}

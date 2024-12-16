using UnityEngine;

public class AttachPoint_R_Wing : MonoBehaviour
{
    public Transform attachTransform; // Point d'attache précis
    public string requiredTag = "r_wing"; // Tag des objets qui peuvent s'accrocher
    public MeshRenderer indicatorRenderer; // Référence locale au MeshRenderer de l'indicateur
    public bool isOccupied = false; // Vérifie si un objet est déjà attaché

    private void OnTriggerEnter(Collider other)
    {
        if (isOccupied) return;

        if (other.CompareTag(requiredTag)) // Vérifie si l'objet peut être attaché
        {
            Debug.Log($"L'objet {other.name} est entré dans la zone de l'AttachPoint {name}.");
            AttachObject(other.gameObject);

            // Désactiver le MeshRenderer de l'indicateur
            HideIndicator();
        }
    }

    private void AttachObject(GameObject obj)
    {
        // Sauvegarder l'échelle d'origine de l'objet
        Vector3 originalScale = obj.transform.localScale;

        // Désactiver tous les scripts sur l'objet
        MonoBehaviour[] scripts = obj.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
        {
            script.enabled = false;
        }

        // Désactiver le collider principal et tous les colliders enfants
        Collider[] colliders = obj.GetComponentsInChildren<Collider>();
        foreach (Collider col in colliders)
        {
            if (col.name != "Screw_Cross")
            {
                Debug.Log("Désactiver le collider de " + col.name);
                col.enabled = false;
            }
            else
            {
                Debug.Log("Conserver le collider de " + col.name);
            }
        }

        // Rendre l'objet immobile
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true; // Désactive la physique
        }

        // Faire de l'objet un enfant de la base
        obj.transform.SetParent(transform, true);

        // Définir la position et la rotation
        obj.transform.position = attachTransform.position;
        obj.transform.rotation = Quaternion.Euler(-181.37f, -87.200f, -88.573f);

        // Ajuster la position locale
        Vector3 localPosition = obj.transform.localPosition;
        localPosition.x -= 0.35f;
        localPosition.z -= 0.50f;
        obj.transform.localPosition = localPosition;

        isOccupied = true; // Marque ce point comme occupé

        Debug.Log($"L'objet {obj.name} a été attaché à l'AttachPoint {name}, colliders (y compris enfants) et scripts désactivés.");
    }

    private void HideIndicator()
    {
        if (indicatorRenderer != null)
        {
            indicatorRenderer.enabled = false;
            Debug.Log($"Le MeshRenderer de l'indicateur {indicatorRenderer.name} a été désactivé.");
        }
        else
        {
            Debug.LogWarning($"Aucun MeshRenderer assigné pour l'indicateur de {name}.");
        }
    }
}

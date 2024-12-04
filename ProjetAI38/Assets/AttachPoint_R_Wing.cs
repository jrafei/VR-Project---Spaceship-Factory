using UnityEngine;

public class AttachPoint_R_Wing : MonoBehaviour
{
    public Transform attachTransform; // Point d'attache précis
    public string requiredTag = "r_wing"; // Tag des objets qui peuvent s'accrocher
    public bool isOccupied = false; // Vérifie si un objet est déjà attaché

    private void OnTriggerEnter(Collider other)
    {
        if (isOccupied) return;

        if (other.CompareTag(requiredTag)) // Vérifie si l'objet peut être attaché
        {
            Debug.Log($"L'objet {other.name} est entré dans la zone de l'AttachPoint {name}.");
            AttachObject(other.gameObject);
        }
    }

    private void AttachObject(GameObject obj)
    {

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
            col.enabled = false;
        }

        // Rendre l'objet immobile
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true; // Désactive la physique
        }

        // Faire de l'objet un enfant de la base
        obj.transform.SetParent(transform, false);


        // Définir la position et la rotation
        obj.transform.position = attachTransform.position;
        obj.transform.localRotation = Quaternion.Euler(-269.9f, -56.8f, -55.3f);

        // Baisser la position locale en Y
        Vector3 localPosition = obj.transform.localPosition;
        localPosition.x -= 0.3f; // Par exemple, abaisse de 0.5 unités
        localPosition.z -= 0.2f; // Par exemple, abaisse de 0.5 unités
        localPosition.y += 1f; // Par exemple, abaisse de 0.5 unités
        obj.transform.localPosition = localPosition;




        isOccupied = true; // Marque ce point comme occupé

        Debug.Log($"L'objet {obj.name} a été attaché à l'AttachPoint {name}, colliders (y compris enfants) et scripts désactivés.");
    }
}

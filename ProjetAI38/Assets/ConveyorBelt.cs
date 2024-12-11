using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float conveyorSpeed = 2f; // Vitesse du convoyeur
    public Transform endPoint; // Point de fin du convoyeur

    private void OnCollisionEnter(Collision collision)
    {
        // Vérifier si l'objet peut être déplacé
        if (collision.gameObject.CompareTag("core"))
        {
            MoveObject(collision.gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        // Déplacer l'objet tant qu'il est sur le convoyeur
        if (collision.gameObject.CompareTag("core"))
        {
            MoveObject(collision.gameObject);
        }
    }

    private void MoveObject(GameObject obj)
    {
        // Calculer la direction vers la fin du convoyeur
        Vector3 direction = (endPoint.position - obj.transform.position).normalized;

        // Déplacer l'objet dans la direction avec la vitesse définie
        obj.transform.position += direction * conveyorSpeed * Time.deltaTime;

        // Optionnel : Arrêter l'objet s'il atteint la fin
        float distanceToEnd = Vector3.Distance(obj.transform.position, endPoint.position);
        if (distanceToEnd < 0.1f)
        {
            Debug.Log($"{obj.name} a atteint la fin du convoyeur.");
        }
    }
}

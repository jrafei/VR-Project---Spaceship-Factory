using UnityEngine;

public class NavMeshZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Agent")) // Vérifie que c'est l'agent
        {
            Debug.Log("Agent entré dans le NavMesh !");
        }
    }
}

using UnityEngine;
using UnityEngine.AI;

public class AgentMovement : MonoBehaviour
{
    public Transform target; // L'objet cible

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (target != null)
        {
            agent.SetDestination(target.position); // Définit la destination
        }
    }
}

using UnityEngine;

public class SpawnComponents : MonoBehaviour
{
    public GameObject rWingPrefab; // Le prefab r_wing à instancier
    public GameObject lWingPrefab; // Le prefab l_wing à instancier
    public GameObject thrusterPrefab; // Le prefab thruster à instancier

    // Position, rotation et échelle pour r_wing
    private Vector3 rWingPosition = new Vector3(8.8f, 11.57f, -23.75f);
    private Quaternion rWingRotation = new Quaternion(-0.52412325f, -0.49971256f, -0.48758882f, -0.48768777f);
    private Vector3 rWingScale = new Vector3(1.0f, 0.51627886f, 0.37492079f);

    // Position, rotation et échelle pour l_wing
    private Vector3 lWingPosition = new Vector3(8.84f, 11.73f, -35.48f);
    private Quaternion lWingRotation = new Quaternion(0.49637711f, -0.52728349f, 0.48458406f, -0.49067327f);
    private Vector3 lWingScale = new Vector3(1.0f, 0.51627886f, 0.37492079f);

    // Position, rotation et échelle pour thruster
    private Vector3 thrusterPosition = new Vector3(19.32f, 11.525f, -36.49f);
    private Quaternion thrusterRotation = new Quaternion(0.0f, -0.69216829f, 0.0f, 0.72173619f);
    private Vector3 thrusterScale = new Vector3(0.45158082f, 0.43376979f, 0.44111901f);

    public void SpawnRWing()
    {
        if (rWingPrefab != null)
        {
            // Instancier le prefab r_wing
            GameObject spawnedObject = Instantiate(rWingPrefab, rWingPosition, rWingRotation);
            spawnedObject.transform.localScale = rWingScale;

            Debug.Log("Prefab r_wing spawné à la position spécifiée.");
        }
        else
        {
            Debug.LogError("Aucun prefab assigné pour r_wing !");
        }
    }

    public void SpawnLWing()
    {
        if (lWingPrefab != null)
        {
            // Instancier le prefab l_wing
            GameObject spawnedObject = Instantiate(lWingPrefab, lWingPosition, lWingRotation);
            spawnedObject.transform.localScale = lWingScale;

            Debug.Log("Prefab l_wing spawné à la position spécifiée.");
        }
        else
        {
            Debug.LogError("Aucun prefab assigné pour l_wing !");
        }
    }

    public void SpawnThruster()
    {
        if (thrusterPrefab != null)
        {
            // Instancier le prefab thruster
            GameObject spawnedObject = Instantiate(thrusterPrefab, thrusterPosition, thrusterRotation);
            spawnedObject.transform.localScale = thrusterScale;

            Debug.Log("Prefab thruster spawné à la position spécifiée.");
        }
        else
        {
            Debug.LogError("Aucun prefab assigné pour thruster !");
        }
    }
}

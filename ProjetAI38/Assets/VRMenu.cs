using UnityEngine;
using UnityEngine.SceneManagement;

public class VRMenu : MonoBehaviour
{
    public GameObject corePrefab; // Le prefab Core à instancier
    private bool gameStarted = false; // Pour vérifier si le jeu a commencé
    private GameObject coreInstance; // Référence à l'instance du Core

    public string lWingTag = "l_wing"; // Tag pour les objets l_wing
    public string rWingTag = "r_wing"; // Tag pour les objets r_wing
    public string thrusterTag = "thruster"; // Tag pour les objets thruster
    public string coreTag = "core"; // Tag pour les objets core

    public void StartGame()
    {
        if (!gameStarted)
        {
            gameStarted = true;

            // Instancie le prefab Core à la position et rotation spécifiées
            Vector3 position = new Vector3(9.93f, 12.2f, -29.66f);
            Quaternion rotation = new Quaternion(0.0f, 0.715924f, 0.0f, 0.6981783f);
            Vector3 scale = new Vector3(0.7107f, 0.746025f, 0.45315f);

            coreInstance = Instantiate(corePrefab, position, rotation);
            coreInstance.transform.localScale = scale;

            Debug.Log("Jeu démarré et Core positionné.");
        }
    }

    public void StopGame()
    {
        if (gameStarted)
        {
            gameStarted = false;

            // Supprimer toutes les instances de core
            DestroyAllByTag(coreTag);

            // Supprimer toutes les instances de l_wing
            DestroyAllByTag(lWingTag);

            // Supprimer toutes les instances de r_wing
            DestroyAllByTag(rWingTag);

            // Supprimer toutes les instances de thruster
            DestroyAllByTag(thrusterTag);

            Debug.Log("Jeu arrêté et tous les objets supprimés.");
        }
    }

    private void DestroyAllByTag(string tag)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }
        Debug.Log($"Tous les objets avec le tag {tag} ont été supprimés.");
    }

    public void ReloadScene()
    {
        // Recharge la scène active
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Scène relancée.");
    }
}

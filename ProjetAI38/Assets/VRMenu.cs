using UnityEngine;
using UnityEngine.SceneManagement;

public class VRMenu : MonoBehaviour
{
    public void ReloadScene()
    {
        // Recharge la sc�ne active
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Sc�ne relanc�e.");
    }
}

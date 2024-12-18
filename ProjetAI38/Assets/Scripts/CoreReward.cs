using UnityEngine;
using TMPro; // N�cessaire pour utiliser TextMeshPro

public class CoreReward : MonoBehaviour
{
    public TextMeshProUGUI moneyText; // R�f�rence au TextMeshPro pour afficher l'argent
    public GameObject corePrefab; // Le prefab Core � instancier
    private GameObject coreInstance; // R�f�rence � l'instance du Core
    private int money = 0; // Argent total gagn�

    private void OnCollisionEnter(Collision collision)
    {
        // V�rifie si l'objet qui entre en collision a le tag "core"
        if (collision.gameObject.CompareTag("core"))
        {
            Debug.Log("[CoreReward] Collision avec un core d�tect�e !");

            // Incr�mente l'argent de 1000�
            money += 1000;

            // Met � jour l'affichage du texte
            if (moneyText != null)
            {
                moneyText.text = money + "�";
            }
            else
            {
                Debug.LogError("[CoreReward] TextMeshProUGUI non assign� !");
            }

            // D�truit l'objet core
            Destroy(collision.gameObject);

            // Instancie le prefab Core � la position et rotation sp�cifi�es
            Vector3 position = new Vector3(9.93f, 12.2f, -29.66f);
            Quaternion rotation = new Quaternion(0.0f, 0.715924f, 0.0f, 0.6981783f);
            Vector3 scale = new Vector3(0.7107f, 0.746025f, 0.45315f);

            coreInstance = Instantiate(corePrefab, position, rotation);
            coreInstance.transform.localScale = scale;
        }
    }
}

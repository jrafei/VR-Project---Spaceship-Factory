using UnityEngine;

public class TextFollowPlayer : MonoBehaviour
{
    private Transform player; // R�f�rence au Transform du joueur

    void Start()
    {
        // Trouver l'objet avec le tag "Player" et obtenir son Transform
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Aucun objet avec le tag 'Player' trouv� dans la sc�ne.");
        }
    }

    void Update()
    {
        if (player == null) return;

        // Calculer la direction vers le joueur
        Vector3 directionToPlayer = player.position - transform.position;

        // Annuler tout mouvement en Y pour garder l'orientation � plat
        directionToPlayer.y = 0;

        // Appliquer la rotation pour faire face au joueur
        if (directionToPlayer != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(directionToPlayer);

            // Corriger l'orientation en ajoutant une rotation de 180� autour de l'axe Y
            transform.Rotate(0, 180, 0);
        }
    }
}

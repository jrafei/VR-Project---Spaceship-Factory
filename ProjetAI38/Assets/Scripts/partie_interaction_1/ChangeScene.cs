/* Description: Script permettant de changer de scène lorsque le joueur entre en contact avec un objet taggé "Hand"
 * 
 */
// A REFAIRE

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
	public GameObject LeftHand;
	public GameObject RightHand;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider c) {
		if(c.gameObject.CompareTag("Hand")) {
			/*LeftHand.GetComponent<Deplacement>().changeAction(3); // une méthode changeAction(3) sur un script Deplacement attaché à LeftHand et RightHand
			RightHand.GetComponent<Deplacement>().changeAction(3);
			*/SceneManager.LoadScene("testLab");
			//Application.LoadLevel ("testLab");
		}

	}
}

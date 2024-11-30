using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class attach : MonoBehaviour {
	public GameObject particule;
	public GameObject bout1;
	public GameObject bout2;
	 bool isattached=false;
	float timer=5.0f;
	Rigidbody rb1;
	Rigidbody rb2;
	public Image cooldown;
	bool intrig=false;
	public bool finished=false;
	public Text textinfo;

	// Use this for initialization
	void Start () {
		rb1 = bout1.GetComponent<Rigidbody> ();
		rb2 = bout2.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(intrig)
			timer -= Time.deltaTime;
		
		cooldown.fillAmount = timer / 5.0f;
		if (timer < 0)
			finished = true;
		if (finished) {
			textinfo.text = "Réarmer le disjoncteur en poussant le levier vers l'avant pour remettre le courant.";
		}
	}
	void OnTriggerEnter(Collider other) {


		if (other.gameObject.name=="boutfix") {
			rb1.isKinematic = true;
			rb2.isKinematic = true;
			isattached = true;
			//particule.SetActive(true);
		}
		if (other.gameObject.name == "feu") {
			if (isattached) {
				particule.SetActive (true);
				intrig = true;
			}
		}

	}

	void OnTriggerExit(Collider other) {
		//Debug.Log (other.name);
		if (other.gameObject.name=="feu") {

			particule.SetActive(false);
			intrig = false;
		}
		//
		//plus = true;
	}
}

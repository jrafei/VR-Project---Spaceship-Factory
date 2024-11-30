using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondPart : MonoBehaviour {
	Text indication;
	public GameObject textObject;
	public GameObject LeftHand;
	public GameObject RightHand;
	// Use this for initialization
	void Start () {
		indication = textObject.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider c){
		if (!c.gameObject.CompareTag ("wall")) {
			indication.text = "Avancez jusqu'au bouton en attrapant et tirant les poignets et appuyez dessus";
			//LeftHand.GetComponent<Deplacement>().changeAction(1);
			//RightHand.GetComponent<Deplacement>().changeAction(1);
		}
	}
}

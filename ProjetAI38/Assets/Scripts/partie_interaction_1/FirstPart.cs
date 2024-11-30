using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstPart : MonoBehaviour {
	public GameObject text;
	Animator anim;
	public GameObject LeftHand;
	public GameObject RightHand;
	// Use this for initialization
	void Start () {
		anim = text.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider c){
		if (!c.gameObject.CompareTag ("wall")) {
			anim.SetTrigger("DebutMouvement");
			//LeftHand.GetComponent<Deplacement>().changeAction(2);
			//RightHand.GetComponent<Deplacement>().changeAction(2);
		}
	}
}

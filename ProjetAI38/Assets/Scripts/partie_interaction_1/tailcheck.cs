using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tailcheck : MonoBehaviour {
	Scew s;
	bool incontact;
	Rigidbody rb;
	public bool exit=false;
	Collider col;
	InteractableItem inter;
	// Use this for initialization
	void Start () {
		
		s=gameObject.GetComponentInParent<Scew>();
		incontact = s.incontact;
	}
	
	// Update is called once per frame
	void Update () {
		incontact = s.incontact;
		if (incontact == false)
			s.setplus (false);
	}
	void OnTriggerExit(Collider other) {
		

		if (other.gameObject.CompareTag ("Plaque")) {
			s.setplus (false);
			col = s.GetComponent<BoxCollider> ();
			col.enabled = true;
			inter = s.GetComponent<InteractableItem> ();
			inter.enabled = true;
			rb=s.GetComponent<Rigidbody> ();
			rb.isKinematic = false;
			rb.AddForce (new Vector3 (-1, 1, -2));
			rb.AddTorque (new Vector3 (-6, 0, 0),ForceMode.Impulse);
			exit = true;
		}
	}
	void OnTriggerStay(Collider other) {
		//Debug.Log (other.name);
		if (other.gameObject.CompareTag ("Plaque")) {
			if (incontact)
				s.setplus (true);
		}
		//
			//plus = true;
	}
}

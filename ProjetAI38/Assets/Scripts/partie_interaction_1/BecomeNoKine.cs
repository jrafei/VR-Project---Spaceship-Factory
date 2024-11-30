using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BecomeNoKine : MonoBehaviour {
	public GameObject v1;
	public GameObject v2;
	public GameObject v3;
	public GameObject v4;
	public Text t;
	tailcheck tail;
	bool b1=false;
	bool b2=false;
	bool b3=false;
	bool b4=false;

	Rigidbody rb;
	InteractableItem inter;
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody> ();
		inter = gameObject.GetComponent<InteractableItem> ();

	}
	
	// Update is called once per frame
	void Update () {
		tail = v1.GetComponent<tailcheck> ();
		if (tail.exit == true)
			b1 = true;
		tail = v2.GetComponent<tailcheck> ();
		if (tail.exit == true)
			b2 = true;
		tail = v3.GetComponent<tailcheck> ();
		if (tail.exit == true)
			b3 = true;
		tail = v4.GetComponent<tailcheck> ();
		if (tail.exit == true)
			b4 = true;
		if (b1 == true && b2 == true && b3 == true && b4 == true) {
			rb.isKinematic = false;
			inter.enabled = true;
			t.text = "Souder les deux bout de fils entre eux pour remettre le courant dans le module de stockage";

		}
		
	}
}

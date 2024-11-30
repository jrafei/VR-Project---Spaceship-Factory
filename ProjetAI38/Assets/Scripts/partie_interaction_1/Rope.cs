using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour {

	internal Rigidbody rb;

	// Use this for initialization
	void Start () {
		this.gameObject.AddComponent<Rigidbody> ();
		this.rb = this.gameObject.GetComponent<Rigidbody> ();
		this.rb.isKinematic = true;
		int childCount = this.transform.childCount;
		for (int i = 0; i < childCount; i++) {
			Transform t = this.transform.GetChild (i);
			t.gameObject.AddComponent<HingeJoint> ();

			HingeJoint hinge = t.gameObject.GetComponent<HingeJoint> ();
			hinge.connectedBody =
				i == 0 ? this.rb : this.transform.GetChild (i - 1).GetComponent<Rigidbody> ();
			hinge.useSpring = true;
			hinge.enableCollision = true;
			hinge.useLimits = true;
			}
		this.transform.GetChild (childCount - 1).GetComponent<Rigidbody> ().AddForce (new Vector3 (0.5f, 0.5f, -0.5f), ForceMode.Impulse);
		//
		//this.transform.GetChild (childCount - 1).GetComponent<Rigidbody> ().isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

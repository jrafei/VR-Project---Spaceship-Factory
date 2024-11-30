using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headcheck : MonoBehaviour {
	Scew s;
	// Use this for initialization
	void Start () {
		s=gameObject.GetComponentInParent<Scew>();
		s.incontact = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerExit(Collider other) {
		//Debug.Log (other.name);
		if (other.name == "meche") {

			s.incontact = false;

		} 

	}
	void OnTriggerStay(Collider other) {
		
		if (other.name == "meche") {
			
			s.incontact=true;
		
		} 
	}
}

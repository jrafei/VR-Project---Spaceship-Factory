/*
	A refaire 
	Ce script désactive temporairement le collider d'un objet, puis le réactive après 100 frames
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateCollider : MonoBehaviour {
	float t=100f; // Un compteur pour activer le Collider après un certain temps.
	Collider c; // Une référence au Collider de l'objet sur lequel ce script est attaché.
	// Use this for initialization
	void Start () {
		c = GetComponent<Collider> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!c.enabled) {
			if (t > 0) {
				t--;
			} else {
				c.enabled = true;
			}
			
		}
	}
}
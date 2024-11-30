
/*
A REFAIRE
Ce script permet à un objet d’interagir avec des murs (ou tout objet ayant le tag "wall") 
Lorsqu'il entre en collision :
Il calcule la direction du rebond en utilisant la normale de la surface.
Une force est appliquée pour pousser l'objet légèrement dans la direction opposée
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncing : MonoBehaviour {
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision c){
		if (c.gameObject.CompareTag ("wall")) { // WALL == Airlock_Int_Wall_Starboard
			ContactPoint contact = c.contacts [0]; // Get the contact point of the collision
			rb.AddForce (contact.normal * 0.001f);
		}
	}
}

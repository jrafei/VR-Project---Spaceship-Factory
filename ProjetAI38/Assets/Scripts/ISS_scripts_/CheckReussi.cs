/*
Ce script est utile pour gérer un changement d'état du jeu ou de la progression, 
en combinant des interactions physiques et des mises à jour d'UI.

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckReussi : MonoBehaviour {
	public GameObject c;
	public Text t;
	Rigidbody r;
	// Use this for initialization
	void Start () {
		r = GetComponent<Rigidbody>();
		//r.AddForce(-transform.right * 200f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Zone")) { 
			t.text = "Done !";
			SceneManager.LoadScene("CouloirDéplacement"); // Charge la scène suivante
			//Application.LoadLevel ("CouloirDéplacement");
		}
	}
}

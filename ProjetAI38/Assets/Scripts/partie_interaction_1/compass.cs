// A REFAIRE
/*
contrôle un objet boussole (ou similaire) qui pointe vers des modules spécifiques
en fonction de la progression du joueur dans le jeu, enregistrée via PlayerPrefs
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compass : MonoBehaviour {
	public GameObject module1; // module casier -> casier
	public GameObject module2; // module 2 -> casier 
	public GameObject module3; // ISS -> Airlock_int_crewLock_simp_Door
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.GetInt("finishlevel")==0)
		transform.LookAt (module1.transform.position); // L'objet contenant ce script s'oriente vers module1.
		if(PlayerPrefs.GetInt("finishlevel")==1) 
			transform.LookAt (module2.transform.position); // L'objet contenant ce script s'oriente vers module2.
		if(PlayerPrefs.GetInt("finishlevel")==2) 
			transform.LookAt (module3.transform.position); // L'objet contenant ce script s'oriente vers module3.
	}
}

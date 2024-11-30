/*
Le script FollowEarth est conçu pour que l'objet auquel il est attaché 
suivre la position de son parent dans la hiérarchie ou celle d'un autre objet spécifié (earth)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEarth : MonoBehaviour {
	public GameObject earth;
	// Use this for initialization
	void Start () {
		transform.position = GetComponentInParent<Transform> ().position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = GetComponentInParent<Transform> ().position;
	}
}

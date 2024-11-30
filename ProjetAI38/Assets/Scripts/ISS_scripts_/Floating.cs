/*
simuler un comportement de mouvement flottant dans l'espace
 avec des interactions physiques, comme des collisions.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour {
	private Vector3 direction;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		direction = new Vector3 (Random.Range (-360, 360), Random.Range (-360, 360), Random.Range (-360, 360));
		rb = GetComponent<Rigidbody> ();
		//rb.AddForce(direction);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.gameObject.transform.position = Vector3.Lerp (this.gameObject.transform.position, direction, 0.01f * Time.deltaTime);
	}

	void OnCollisionEnter(Collision collideEvent)
	{
		Vector3 dir = collideEvent.contacts[0].point - transform.position;
		// We then get the opposite (-Vector3) and normalize it
		//Debug.Log("Touché, New dir :"+(-dir));
		this.direction = -dir.normalized;
		rb.AddForce(direction*(50));

	}
}

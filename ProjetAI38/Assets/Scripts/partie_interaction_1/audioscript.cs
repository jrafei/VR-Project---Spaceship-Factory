using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioscript : MonoBehaviour {
	AudioSource aud;
	public AudioClip clip;
	public bool right;
	InteractableItem it;
	// Use this for initialization
	void Start () {
		
		it = gameObject.GetComponent<InteractableItem> ();

		aud = gameObject.AddComponent<AudioSource> ();
		aud.playOnAwake = true;
		aud.clip = clip;
		aud.volume = 1;
	}
	
	// Update is called once per frame
	void Update () {
		right = it.right;
		if (it.IsInteracting ()) {
			if (right == false && Input.GetAxis ("leftbutton") == 1f) {
				Debug.Log ("music");
				aud.Play ();
			}
			if (right == true && Input.GetAxis ("rightbutton") == 1f) {
				aud.Play ();
			} else {
				aud.Stop ();
			}
		}
		
	}
}

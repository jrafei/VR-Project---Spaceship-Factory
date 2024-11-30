using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeRefresh : MonoBehaviour {
	Text t;
	// Use this for initialization
	void Start () {
		t = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		t.text = System.DateTime.Now.ToLongTimeString() + " " + System.DateTime.Now.ToLongDateString();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blink : MonoBehaviour {
	float totalSeconds=1.0f;
	public Light myLight;
	float maxIntensity=6.0f;
	public bool activ = true;
	// Use this for initialization
	void Start () {
		StartCoroutine (flashNow());
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	 public IEnumerator flashNow ()
	{
		float waitTime = totalSeconds / 2;   
		while (activ){
			yield return new WaitForSeconds (waitTime);
		
		}
		
     }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class Suivi : MonoBehaviour {
	public GameObject t;
	Vector3 offset;
	Transform transform;
	public bool droite;
	VRNode Side;
	// Use this for initialization
	void Start () {
		transform = GetComponent<Transform> ();
		if (droite)
			Side = VRNode.RightHand;
		else
			Side = VRNode.LeftHand;
			offset = InputTracking.GetLocalPosition (Side)- InputTracking.GetLocalPosition (VRNode.Head);

		
	}
	
	// Update is called once per frame
	void Update () {
		offset = InputTracking.GetLocalPosition (Side)- InputTracking.GetLocalPosition (VRNode.Head);

		//Vector3 h = new Vector3 (t.transform.position.x, t.transform.position.y , t.transform.position.z);
		transform.localPosition = InputTracking.GetLocalPosition (Side);
		transform.localRotation = InputTracking.GetLocalRotation (Side);

	}
}

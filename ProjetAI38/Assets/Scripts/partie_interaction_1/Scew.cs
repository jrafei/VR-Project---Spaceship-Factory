using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scew : MonoBehaviour {
	private Vector3 startpoint;

	private Vector3 temppoint;

	private bool plus = false;

	public float Movement;

	public float MaxMovement;

	public float RotationX;

	public float RotationY;

	public float RotationZ;
	public bool incontact=false;
	// Use this for initialization
	void Start () {
		startpoint = gameObject.transform.localPosition;

		temppoint = startpoint;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		/*if(temppoint.z >= startpoint.z)
		{

			plus= true;

		}*/


		if(plus == true)

		{
			//moves our gameObject along the y-axis for our variable Movement, which can be edited in Unity 3D
			gameObject.transform.localPosition =new Vector3(temppoint.x,temppoint.y, temppoint.z + Movement);
			//This statement overwrites the variable temppoint with our actual position.
			temppoint = gameObject.transform.localPosition;
			//Now lets do the same for the rotation.
			gameObject.transform.Rotate(RotationX, RotationY, RotationZ);

		}



	}

	public void setplus(bool s)
	{
		plus = s;
	}
	public void setincontact(bool s)
	{
		incontact = s;
	}



}




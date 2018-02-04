using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightDoorBehavior : Behavior
{
	private bool Triggered = false;
	private Vector3 InitialPosition;

	public Vector3 Left;

	private float AmtTraveled;
	// Use this for initialization
	void Start ()
	{
		InitialPosition = transform.position;
		AmtTraveled = 0.0f;
	}

	// Update is called once per frame
	void Update () 
	{
		if(Triggered)
		{
			if(AmtTraveled > 8)
			{
				//GetComponent<Rigidbody>().velocity = Vector3.zero;
				//Destroy(this); //Yes, removing this script component is the desired behavior.
				Triggered = false;
				GetComponent<BoxCollider>().enabled = false;
				GetComponent<MeshRenderer>().enabled = false;
			}
			else
			{
				//GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 5.0f);
				transform.position += Left * -0.025f;
				AmtTraveled += Left.magnitude * 0.025f;
				//print(InitialPosition.z - transform.position.z);
			}
		}
	}

	public override void Activate ()
	{
		Triggered = true;
	}
}

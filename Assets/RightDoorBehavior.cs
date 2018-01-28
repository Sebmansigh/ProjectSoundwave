using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightDoorBehavior : MonoBehaviour
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
			if(AmtTraveled > 7)
			{
				//GetComponent<Rigidbody>().velocity = Vector3.zero;
				//Destroy(this); //Yes, removing this script component is the desired behavior.
				Triggered = false;
				print("click!");
			}
			else
			{
				//GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 5.0f);
				transform.position += Left * -0.1f;
				AmtTraveled += Left.magnitude * 0.1f;
				//print(InitialPosition.z - transform.position.z);
			}
		}
	}

	void SoundActivate ()
	{
		Triggered = true;
	}
}

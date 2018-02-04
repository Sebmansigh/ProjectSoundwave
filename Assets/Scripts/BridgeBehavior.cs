using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeBehavior : Behavior
{
	private bool Triggered = false;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Triggered)
		{
			if(GetComponent<Rigidbody>().position.z >= -30)
			{
				//GetComponent<Rigidbody>().velocity = Vector3.zero;
				Destroy(this); //Yes, removing this script component is the desired behavior.
			}
			else
			{
				//GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 5.0f);
				GetComponent<Rigidbody>().position += new Vector3(0.0f, 0.0f, 0.25f);
			}
		}
	}

	public override void Activate ()
	{
		Triggered = true;
	}
}

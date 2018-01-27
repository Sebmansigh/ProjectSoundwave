using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeBehavior : MonoBehaviour
{
	private int ticks;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(! GetComponent<Rigidbody>().velocity.Equals(Vector3.zero) )
		{
			if(GetComponent<Rigidbody>().position.z >= -30)
			{
				GetComponent<Rigidbody>().velocity = Vector3.zero;
			}
		}
	}

	void SoundActivate ()
	{
		print("ACTIVATED!");
		GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 5.0f);
	}
}

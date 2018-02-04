using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PressurePlateDevice : Device
{
	private bool triggered = false;
	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{

	}

	void onTriggerEnter(Collider other)
	{
		if(!triggered && other.gameObject == GameObject.Find("PlayerWrapper"))
		{
			print("firing!");
			triggered = true;
			Fire();
		}
		else
		{
			print(other.gameObject.name);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PressurePlateDevice : Device
{
	private bool triggered = false;

	// Update is called once per frame
	void Update ()
	{

	}

	public void Press()
	{
		triggered = true;
		Fire();
	}

}
 
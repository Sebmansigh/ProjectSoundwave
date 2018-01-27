using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeTrigger : MonoBehaviour {

	GameObject Bridge;
	bool triggered = false;

	// Use this for initialization
	void Start ()
	{
		Bridge = GameObject.Find("Bridge");
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnSoundTrigger () 
	{
		if(!triggered)
		{
			Bridge.SendMessage("SoundActivate");
			triggered = true;
		}
	}
}

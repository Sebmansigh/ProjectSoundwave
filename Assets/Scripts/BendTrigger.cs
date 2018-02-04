using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BendTrigger : MonoBehaviour {

	GameObject Bend;
	bool triggered = false;

	// Use this for initialization
	void Start ()
	{
		Bend = GameObject.Find("Bend");
	}

	// Update is called once per frame
	void Update ()
	{

	}

	void OnSoundTrigger () 
	{
		if(!triggered)
		{
			Bend.SendMessage("SoundActivate");
			triggered = true;
		}
	}
}

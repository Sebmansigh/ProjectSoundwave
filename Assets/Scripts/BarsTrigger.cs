using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarsTrigger : Trigger
{
	public GameObject m_Bars;

	bool triggered = false;

	// Use this for initialization
	void Start ()
	{
		Register(m_Bars.AddComponent<BarsBehavior>());
	}

	// Update is called once per frame
	void Update ()
	{

	}

	public override void OnTrigger(Device sender) 
	{
		if(!triggered)
		{
			ActivateAll();
			triggered = true;
		}
	}
} 

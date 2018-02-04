using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeTrigger : Trigger {

	public GameObject m_Bridge;
	bool triggered = false;

	// Use this for initialization
	void Start()
	{
		Register(m_Bridge.AddComponent<BridgeBehavior>());
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

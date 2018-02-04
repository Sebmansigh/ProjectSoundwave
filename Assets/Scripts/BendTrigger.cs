using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BendTrigger : Trigger {

	public GameObject m_Bend;
	bool triggered = false;

	// Use this for initialization
	void Start ()
	{
		Register(m_Bend.AddComponent<BendBehavior>());
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

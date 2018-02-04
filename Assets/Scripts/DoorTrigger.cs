using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : Trigger
{
	public GameObject m_DoorLeft;
	public GameObject m_DoorRight;

	bool triggered = false;

	// Use this for initialization
	void Start ()
	{
		Vector3 Left =  m_DoorLeft.transform.position - m_DoorRight.transform.position;
		//print(m_DoorRight.GetComponent<Rigidbody>().position + " - " + m_DoorLeft.GetComponent<Rigidbody>().position);
		LeftDoorBehavior L = m_DoorLeft.AddComponent<LeftDoorBehavior>();
		RightDoorBehavior R = m_DoorRight.AddComponent<RightDoorBehavior>();
		Register(L);
		Register(R);
		R.Left = L.Left = Left;
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

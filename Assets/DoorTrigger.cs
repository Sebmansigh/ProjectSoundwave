using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
	public GameObject m_DoorLeft;
	public GameObject m_DoorRight;

	bool triggered = false;

	// Use this for initialization
	void Start ()
	{
		Vector3 Left =  m_DoorLeft.GetComponent<Rigidbody>().position - m_DoorRight.GetComponent<Rigidbody>().position;
		//print(m_DoorRight.GetComponent<Rigidbody>().position + " - " + m_DoorLeft.GetComponent<Rigidbody>().position);
		m_DoorLeft.AddComponent<LeftDoorBehavior>().Left = Left;
		m_DoorRight.AddComponent<RightDoorBehavior>().Left = Left;
	}

	// Update is called once per frame
	void Update ()
	{

	}

	void OnSoundTrigger () 
	{
		if(!triggered)
		{
			m_DoorLeft.SendMessage("SoundActivate");
			m_DoorRight.SendMessage("SoundActivate");
			triggered = true;
		}
	}
}

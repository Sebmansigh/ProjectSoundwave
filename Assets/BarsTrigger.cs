using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarsTrigger : MonoBehaviour
{
	public GameObject m_Bars;

	bool triggered = false;

	// Use this for initialization
	void Start ()
	{
		m_Bars.AddComponent<BarsBehavior>();
	}

	// Update is called once per frame
	void Update ()
	{

	}

	void OnSoundTrigger () 
	{
		if(!triggered)
		{
			m_Bars.SendMessage("SoundActivate");
			triggered = true;
		}
	}
}

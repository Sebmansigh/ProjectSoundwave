using System;
using UnityEngine;

public abstract class Device : MonoBehaviour
{
	public void Fire()
	{
		foreach(Trigger c in gameObject.GetComponents<Trigger>())
		{
			c.OnTrigger(this);
		}
		GetComponent<AudioSource>().Play();
		print("Fired by: " + name);
	}
}

 
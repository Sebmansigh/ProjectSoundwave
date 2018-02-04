using System.Collections.Generic;
using UnityEngine;

public abstract class Trigger : MonoBehaviour
{
	private HashSet<Behavior> Behaviors = new HashSet<Behavior>();

	public abstract void OnTrigger(Device sender);
	protected void Register(Behavior b)
	{
		Behaviors.Add(b);
	}

	protected void ActivateAll()
	{
		foreach(Behavior b in Behaviors)
		{
			b.Activate();
		}
	}
}


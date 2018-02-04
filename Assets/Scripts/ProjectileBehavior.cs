using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileBehavior : MonoBehaviour
{
	public Vector3 Velocity { get; set; }
	private Rigidbody Body;
	private HashSet<GameObject> IgnoredMirrors;

	public static bool IsMirror(GameObject O)
	{
		try
		{
			return O.GetComponent<MeshRenderer>().material.name.StartsWith("mirror");
		}
		catch
		{
			return false;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other is MeshCollider)
		{
			Destroy(gameObject);
			return;
		}
		else if(other.gameObject.GetComponent<SoundReceiverDevice>() != null)
		{
			Destroy(gameObject);
			other.gameObject.GetComponent<SoundReceiverDevice>().Fire();
			return;
		}
		else if(IsMirror(other.gameObject))
		{
			GameObject Mirror = other.gameObject;
			if(!IgnoredMirrors.Contains(Mirror))
			{
				Bounce(Mirror);
				IgnoredMirrors.Add(Mirror);
			}
		}
	}

	void OnTriggerLeave(Collider other)
	{
		IgnoredMirrors.Remove(other.gameObject);
	}

	void Bounce(GameObject Mirror)
	{
		Velocity = Vector3.Reflect(Velocity,Mirror.transform.up);
	}

	void Start()
	{
		Body = GetComponent<Rigidbody>();
		IgnoredMirrors = new HashSet<GameObject>();
	}

	void Update()
	{
		//transform.position += Velocity;
		Body.velocity = Velocity;

		if(Mathf.Abs(gameObject.transform.position.y) > 100)
		{
			Destroy(gameObject);
		}
	}
}

public sealed class Projectile
{
	private Projectile()
	{}

	public static GameObject CreateProjectile(Vector3 position, Quaternion rotation, Vector3 velocity)
	{
		GameObject projectile = GameObject.Instantiate(GameObject.Find("SoundSphere"));
		projectile.transform.position = position;
		projectile.transform.rotation *= rotation;
		projectile.GetComponent<ProjectileBehavior>().Velocity = velocity;
		return projectile;
	}
}
 
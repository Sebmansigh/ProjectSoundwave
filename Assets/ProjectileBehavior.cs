using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
	public Vector3 Velocity { get; set; }
	private Rigidbody Body;

	void OnTriggerEnter(Collider other)
	{
		if(other is MeshCollider)
		{
			Destroy(gameObject);
			return;
		}
		if(other.gameObject.name.StartsWith("SoundReciever"))
		{
			Destroy(gameObject);
			other.gameObject.SendMessage("OnSoundTrigger");
			return;
		}
	} 

	void Start()
	{
		Body = GetComponent<Rigidbody>();
	}

	void Update()
	{
		//transform.position += Velocity;
		Body.velocity = Velocity;
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
		projectile.transform.rotation = rotation;
		projectile.GetComponent<ProjectileBehavior>().Velocity = velocity;
		return projectile;
	}
}

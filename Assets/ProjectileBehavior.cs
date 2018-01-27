using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
	public Vector3 Velocity { get; set; }
	private CharacterController Controller;

	void OnTriggerEnter(Collider other)
	{
		if(other is MeshCollider)
		{
			Destroy(gameObject);
		}
	} 

	void Start()
	{
		Controller = GetComponent<CharacterController>();
	}

	void Update()
	{
		//transform.position += Velocity;
		Controller.Move(Velocity);
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
		/*
		GameObject projectile = GameObject.CreatePrimitive(PrimitiveType.Sphere);

		projectile.transform.position = position;

		ProjectileBehavior b = projectile.AddComponent<ProjectileBehavior>();
		b.Velocity = velocity;
		*/
		return projectile;
	}
}

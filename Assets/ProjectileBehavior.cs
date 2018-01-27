using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
	public Vector3 Velocity { get; set; }

	void Start()
	{
	}

	void Update()
	{
		transform.position += Velocity;
	}
}

public sealed class Projectile
{
	private Projectile()
	{}

	public static GameObject CreateProjectile(Vector3 position, Vector3 velocity)
	{
		GameObject projectile = GameObject.CreatePrimitive(PrimitiveType.Sphere);

		projectile.transform.position = position;

		ProjectileBehavior b = projectile.AddComponent<ProjectileBehavior>();
		b.Velocity = velocity;

		return projectile;
	}
}

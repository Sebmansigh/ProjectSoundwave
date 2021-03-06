﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

	private CharacterController Controller;
	private GameObject Wrapper;
	private float MoveSpeed = 0.3f;
	private float RotSpeed = 5f;
	private float Yview = 0.0f;
	private const float GRAVITY = -1.0f;
	private float Yvelocity = 0.0f;
	private Vector3 InitialPosition;

	// Use this for initialization
	void Start() 
	{
		Wrapper = GameObject.Find("PlayerWrapper");
		Controller = GetComponent<CharacterController>();
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		InitialPosition = transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		HandleMovement();
		HandleAimShoot();
	}

	private void HandleAimShoot()
	{
		if(Input.GetMouseButtonDown(0))
		{
			Vector3 ProjectileVelocity = (Camera.main.transform.rotation * Vector3.forward)/3;
			GameObject Gun = GameObject.Find("WaveSpawner");
			Projectile.CreateProjectile(Gun.transform.position, Camera.main.transform.rotation, ProjectileVelocity);
			Gun.GetComponent<AudioSource>().Play();
			//print (Wrapper.transform.rotation + " " + Camera.main.transform.rotation);
		}
	}

	private void HandleMovement()
	{
		Wrapper.transform.Rotate(0, Input.GetAxis("Mouse X")* RotSpeed, 0);
		float ModifyY = -Input.GetAxis("Mouse Y")*RotSpeed;
		Yview += ModifyY;
		if(Yview > 90)
		{
			ModifyY -= Yview - 90;
			Yview = 90f;
		}
		if(Yview < -90)
		{
			ModifyY -= Yview + 90;
			Yview = -90f; 
		}

		Camera.main.transform.Rotate(ModifyY, 0, 0);


		Vector3 Dir = Vector3.zero;
		if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
		{
			Dir.z += MoveSpeed;
		}
		if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
		{
			Dir.z -= MoveSpeed;
		}
		if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
			Dir.x -= MoveSpeed;
		}
		if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
			Dir.x += MoveSpeed;
		}

		//
		if(Controller.isGrounded)
		{
			Yvelocity = 0.0f;
			if(Input.GetKey(KeyCode.Space))
			{
				Yvelocity = 0.5f;
			}
		}
		else
		{
			Yvelocity += GRAVITY / 60;
		}

		Vector3 MoveVector = Wrapper.transform.rotation * Vector3.ClampMagnitude(Dir, MoveSpeed);
		MoveVector += new Vector3(0, Yvelocity, 0);

		Controller.Move(MoveVector);

		//
		if(transform.position.y < -15)
		{
			transform.position = InitialPosition;
		}
	}

	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if(hit.gameObject.GetComponent<PressurePlateDevice>() != null)
		{
			hit.gameObject.GetComponent<PressurePlateDevice>().Press();
		}
	}
}
 
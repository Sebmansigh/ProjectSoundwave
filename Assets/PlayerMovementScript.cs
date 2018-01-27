using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

	private CharacterController Controller;
	private GameObject Wrapper;
	private float MoveSpeed = 0.3f;
	private float RotSpeed = 5f;

	// Use this for initialization
	void Start()
	{
		Wrapper = GameObject.Find("PlayerWrapper");
		Controller = (CharacterController)GetComponent(typeof(CharacterController));
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	// Update is called once per frame
	void Update()
	{
		Wrapper.transform.Rotate(0, Input.GetAxis("Mouse X")* RotSpeed, 0);
//		Camera.main.transform.Rotate(-Input.GetAxis("Mouse Y")* RotSpeed, 0, 0);


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
		Vector3 MoveVector = Vector3.ClampMagnitude(Dir, MoveSpeed);
		Controller.Move(Wrapper.transform.rotation * MoveVector);
	}
}

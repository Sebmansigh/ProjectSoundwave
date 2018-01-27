using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

	private CharacterController Controller;
	private float MoveSpeed = 0.3f;

	// Use this for initialization
	void Start()
	{
		Controller = (CharacterController)GetComponent(typeof(CharacterController));
	}
	
	// Update is called once per frame
	void Update()
	{
		Vector3 Dir = Vector3.zero;
		if(Input.GetKey(KeyCode.UpArrow))
		{
			Dir.z += MoveSpeed;
		}
		if(Input.GetKey(KeyCode.DownArrow))
		{
			Dir.z -= MoveSpeed;
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			Dir.x -= MoveSpeed;
		}
		if(Input.GetKey(KeyCode.RightArrow))
		{
			Dir.x += MoveSpeed;
		}
		Controller.Move( Vector3.ClampMagnitude(Dir, MoveSpeed) );
	}
}

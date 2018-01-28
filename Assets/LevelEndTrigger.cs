using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter()
	{
		GameObject.Find("LevelEndText").GetComponent<MeshRenderer>().enabled = true;
		Destroy(this);
	}
}

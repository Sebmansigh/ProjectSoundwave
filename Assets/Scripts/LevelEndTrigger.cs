using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndTrigger : Trigger {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void OnTrigger(Device sender)
	{
		GameObject.Find("LevelEndText").GetComponent<MeshRenderer>().enabled = true;
	}
}
 
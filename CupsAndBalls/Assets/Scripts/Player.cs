﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public bool canPick = false;
	public bool picked = false;
	public bool won = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (canPick == true)
		{
			if (GvrPointerInputModule.Pointer.TriggerDown ||
				Input.GetMouseButtonDown(0) ||
				Input.GetKeyDown(KeyCode.Space))
			{
				RaycastHit hit;
				if (Physics.Raycast(transform.position, transform.forward, out hit))
				{
					Cup cup = hit.transform.GetComponent<Cup> ();
					if (cup != null)
					{
						canPick = false;
						picked = true;
						won = (cup.ball != null); // cup is holding the ball

						cup.MoveUp();
					}
				}
			}
		}
	}
}

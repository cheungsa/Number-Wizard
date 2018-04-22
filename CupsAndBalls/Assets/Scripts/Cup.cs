using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour {

	public float downHeight = 1.19f;
	public float upHeight = 1.4f;
	public float speed = 2.5f;
	public GameObject ball;
	public Vector3 targetPosition;

	// Use this for initialization
	void Start () {
		targetPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		// Make cups slowly move to target position
		transform.position = Vector3.Lerp (transform.position, targetPosition, Time.deltaTime * speed);

		// Moves ball along with the cup it is hiding in
		if (ball != null)
		{
			ball.transform.position = new Vector3 (
				transform.position.x,
				ball.transform.position.y,
				transform.position.z
			);
		}
	}

	public void MoveUp () {
		targetPosition = new Vector3 (
			transform.position.x,
			upHeight,
			transform.position.z
		);
	}

	public void MoveDown () {
		targetPosition = new Vector3 (
			transform.position.x,
			downHeight,
			transform.position.z
		);
	}

}

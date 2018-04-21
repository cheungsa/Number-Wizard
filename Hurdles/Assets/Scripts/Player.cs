using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float maxSpeed = 5.5f;
	public float acceleration = 1f;
	public float jumpingForce = 300f;
	public float jumpingCooldown = 1.5f;
	public bool reachedFinishLine = false;

	private float speed = 0f;
	private float jumpingTimer = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Change the player's speed/frame
		if (speed > maxSpeed)
		{
			speed = maxSpeed;
		}
		speed += acceleration * Time.deltaTime;

		// Move the player forward at speed/frame
		transform.position += speed * Vector3.forward * Time.deltaTime;

		// Make the player jump
		jumpingTimer -= Time.deltaTime;
		if (GvrPointerInputModule.Pointer.TriggerDown || 
			Input.GetMouseButtonDown(0) || 
			Input.GetKeyDown(KeyCode.Space))
		{
			if (jumpingTimer <= 0f)
			{
				jumpingTimer = jumpingCooldown;
				this.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpingForce);
			}
		}
	}

	// Decrease the player's speed if an obstacle is hit
	void OnTriggerEnter (Collider collider) {
		if (collider.tag == "Obstacle")
		{
			speed *= 0.3f;
		}

		if (collider.tag == "FinishLine")
		{
			reachedFinishLine = true;
		}
	}
}

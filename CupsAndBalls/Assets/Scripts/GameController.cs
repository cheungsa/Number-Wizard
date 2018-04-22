using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject ball;
	public Cup[] cups;
	public Player player;
	public TextMesh infoText;

	private float resetTimer = 3f;

	// Use this for initialization
	void Start () {
		infoText.text = "Pick the correct cup!";

		StartCoroutine(ShuffleRoutine());	
	}
	
	// Update is called once per frame
	void Update () {
		if (player.picked)
		{
			if (player.won)
			{
				infoText.text = "You won!";
			}
			else
			{
				infoText.text = "You lose :(\n Try again!";
			}

			resetTimer -= Time.deltaTime;
			if (resetTimer <= 0f)
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		}
	}

	private IEnumerator ShuffleRoutine () {
		// Wait one second
		yield return new WaitForSeconds(1f);

		// Move cups up
		foreach (Cup cup in cups) 
		{
			cup.MoveUp();
		}

		// Wait for half a second
		yield return new WaitForSeconds(0.5f);

		Cup targetCup = cups[Random.Range(0, cups.Length)];
		targetCup.ball = ball; // stores ball in cup
		ball.transform.position = new Vector3 (
			targetCup.transform.position.x,
			ball.transform.position.y,
			targetCup.transform.position.z
		);

		// Wait for one second
		yield return new WaitForSeconds(1f);

		foreach (Cup cup in cups)
		{
			cup.MoveDown();
		}

		// Wait for one second
		yield return new WaitForSeconds(1f);

		// Shuffle the cups five times
		for (int i=0; i<5; i++)
		{
			Cup cup1 = cups[Random.Range(0, cups.Length)];
			Cup cup2 = cup1;

			// Ensures that cup2 is different from cup1
			while (cup2 == cup1)
			{
				cup2 = cups[Random.Range(0, cups.Length)];
			}

			// Moves cup2's position to cup1's
			Vector3 cup1Position = cup1.targetPosition;
			cup1.targetPosition = cup2.targetPosition;
			cup2.targetPosition = cup1Position;

			// Wait for 0.6 second
			yield return new WaitForSeconds(0.6f);
		}

		// Allow player to pick a cup
		player.canPick = true;
	}
}

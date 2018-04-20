using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject moleContainer;
	public TextMesh infoText;
	public Player player;
	public float spawnDuration = 1.5f;
	public float spawnDecrement = 0.1f;
	public float minSpawnDuration = 0.5f;
	public float gameTimer = 30f;

	private Mole[] moles;
	private float spawnTimer = 0f;
	private float resetTimer = 3f;

	// Use this for initialization
	void Start () {
		moles = moleContainer.GetComponentsInChildren<Mole> ();
		moles[Random.Range(0, moles.Length)].Rise();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameTimer > 0f)
		{
			gameTimer -= Time.deltaTime;
			if (gameTimer > 0f)
			{
				infoText.text = "Hit all the moles!\nTime: " + Mathf.Floor(gameTimer) + "\nScore: " + player.score;
				spawnTimer -= Time.deltaTime;
				if (spawnTimer <= 0f) 
				{
					moles[Random.Range(0, moles.Length)].Rise();
					spawnDuration -= spawnDecrement;
					if (spawnDuration < minSpawnDuration) 
					{
						spawnDuration = minSpawnDuration;
					}
					spawnTimer = spawnDuration;
				}
			}
		}
		else
		{
			infoText.text = "Game over! Your score: " + Mathf.Floor(player.score);
			resetTimer -= Time.deltaTime;
			if (resetTimer <= 0f)
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		}
	}
}

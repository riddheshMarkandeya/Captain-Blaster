using UnityEngine;
using UnityEngine.UI; // Note this new line is needed for UI

public class GameManager : MonoBehaviour
{
	public Text scoreText;
	public Text gameOverText;
	public Text timeText;
	public AudioClip gameOverSound;

	int playerScore = 0;
	float elapsedTime = 0f;
	AudioSource backgroundMusicSource;

	void Start() {
		backgroundMusicSource = GetComponent<AudioSource>();
	}

	void Update()
	{
		if (!gameOverText.enabled) {
			elapsedTime += Time.deltaTime;
			timeText.text = elapsedTime.ToString("0.00");
		}
	}

	public void AddScore()
	{
		playerScore++;
		// This converts the score (a number) into a string
		scoreText.text = playerScore.ToString();
	}

	public void PlayerDied()
	{
		backgroundMusicSource.Stop();
		backgroundMusicSource.clip = gameOverSound;
		backgroundMusicSource.loop = false;
		backgroundMusicSource.Play();
		gameOverText.enabled = true;
		// This freezes the game
		Time.timeScale = 0;
	}
}


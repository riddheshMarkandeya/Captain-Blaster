using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed = 10f;
	// public GameObject explosionEffectPrefab;
	// public GameObject shieldPowerUpPrefab;
	// public GameObject bulletPowerUpPrefab;
	// public float powerUpLifeSpan = 5f;

	GameManager gameManager; // Note this is private this time

	void Start()
	{
		// Because the bullet doesn�t exist until the game is running
		// we must find the Game Manager a different way.
		gameManager = GameObject.FindObjectOfType<GameManager>();

		Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
		rigidBody.velocity = new Vector2(0f, speed);
	}

	// void SpawnPowerUp() {
	// 	int bulletNumber = Random.Range(1, 21);
	// 	int shieldNumber = Random.Range(1, 41);
	// 	bool spawnBullet = bulletNumber == 5;
	// 	bool spawnShield = shieldNumber == 5;
	// 	if (spawnShield) {
	// 		GameObject powerup = Instantiate(shieldPowerUpPrefab, transform.position, Quaternion.identity);
	// 		Destroy(powerup, powerUpLifeSpan);
	// 		return;
	// 	}
	// 	if (spawnBullet) {
	// 		GameObject powerup = Instantiate(bulletPowerUpPrefab, transform.position, Quaternion.identity);
	// 		Destroy(powerup, powerUpLifeSpan);
	// 	}
	// }

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Meteor") {
			// Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity); // Do meteor explosion
			// Destroy(other.gameObject); // Destroy the meteor
			MeteorMover meteor = other.gameObject.GetComponent<MeteorMover>();
			meteor.GetHit(true); // hit the meteor
			gameManager.AddScore(); // Increment the score
			Destroy(gameObject); // Destroy the bullet
		}
	}
}

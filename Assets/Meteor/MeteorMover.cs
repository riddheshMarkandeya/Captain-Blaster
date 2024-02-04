using UnityEngine;

public class MeteorMover : MonoBehaviour
{
	public float speed = -2f;
	public int health = 1;
	public GameObject explosionEffectPrefab;
	public GameObject shieldPowerUpPrefab;
	public GameObject bulletPowerUpPrefab;
	public float powerUpLifeSpan = 5f;

	Rigidbody2D rigidBody;

	void Start()
	{
		rigidBody = GetComponent<Rigidbody2D>();
		// Give meteor an initial downward velocity
		rigidBody.velocity = new Vector2(0, speed);
	}

	void SpawnPowerUp() {
		int bulletNumber = Random.Range(1, 21);
		int shieldNumber = Random.Range(1, 41);
		bool spawnBullet = bulletNumber == 5;
		bool spawnShield = shieldNumber == 5;
		if (spawnShield) {
			GameObject powerup = Instantiate(shieldPowerUpPrefab, transform.position, Quaternion.identity);
			Destroy(powerup, powerUpLifeSpan);
			return;
		}
		if (spawnBullet) {
			GameObject powerup = Instantiate(bulletPowerUpPrefab, transform.position, Quaternion.identity);
			Destroy(powerup, powerUpLifeSpan);
		}
	}

	public void GetHit(bool isBullet) {
		health--; // Decrement health on hit
		if (health <= 0) {
			Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
			Destroy(gameObject); // Destroy meteor if health is 0 or less

			if (isBullet) {
				SpawnPowerUp();
			}
		}
	}
}


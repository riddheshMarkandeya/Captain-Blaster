using UnityEngine;
using System.Collections;

public class ShipControl : MonoBehaviour
{
	public GameManager gameManager;
	public GameObject bulletPrefab;
	public GameObject shieldPrefab;
	public float speed = 10f;
	public float xLimit = 7f;
	public float yLimit = 5f;
	public float defaultReloadTime = 0.5f;
	public float reloadTime = 0.5f;
	public float bulletPowerUpSpan = 5f;
	public AudioClip powerUpClip;

	float elapsedTime = 0f;
	bool bulletPowerUpOn = false;
	Coroutine bulletReloadResetCoroutine;
	AudioSource powerUpSoundSource;

	void Start() {
		powerUpSoundSource = GetComponent<AudioSource>();
		powerUpSoundSource.clip = powerUpClip;
	}

	void Update()
	{
		// Keeping track of time for bullet firing
		elapsedTime += Time.deltaTime;

		// Move the player left and right
		float xInput = Input.GetAxis("Horizontal");
		// Move the player left and right
		float yInput = Input.GetAxis("Vertical");
		transform.Translate(xInput * speed * Time.deltaTime, yInput * speed * Time.deltaTime, 0f);

		// Clamp the ship�s x position
		Vector3 position = transform.position;
		position.x = Mathf.Clamp(position.x, -xLimit, xLimit);
		position.y = Mathf.Clamp(position.y, -yLimit, yLimit);
		transform.position = position;

		// Spacebar fires. The default InputManager settings call this �Jump�
		// Only happens if enough time has elapsed since last firing.
		if (Input.GetButtonDown("Jump") && elapsedTime > reloadTime)
		{
			// Instantiate two bullets on either sides of the spaceship
			Vector3 currentPos = transform.position;
			Vector3 spawnPos1 = currentPos + new Vector3(-0.5f, 1f, 0);
			Vector3 spawnPos2 = currentPos + new Vector3(0.5f, 1f, 0);
			Instantiate(bulletPrefab, spawnPos1, Quaternion.identity);
			Instantiate(bulletPrefab, spawnPos2, Quaternion.identity);

			elapsedTime = 0f; // Reset bullet firing timer
		}
	}

	IEnumerator ResetReloadTimeAfterDelay(float delay)
	{
		// Wait for the specified delay
		yield return new WaitForSeconds(delay);

		// Change the variable value
		if (bulletPowerUpOn) {
			reloadTime = defaultReloadTime;
			bulletPowerUpOn = false;
		}
	}

	void PlayPowerUpSound() {
		powerUpSoundSource.Play();
	}

	// If a meteor hits the player
	void OnTriggerEnter2D(Collider2D other)
	{
		// print("ship:" + other.gameObject.name);
		if (other.gameObject.tag == "Meteor") {
			gameManager.PlayerDied();
		}
		if (other.gameObject.tag == "ShieldPowerUp") {
			Destroy(other.gameObject);
			PlayPowerUpSound();
			shieldPrefab.SetActive(true);
		}
		if (other.gameObject.tag == "BulletPowerUp") {
			Destroy(other.gameObject);
			PlayPowerUpSound();
			if (bulletReloadResetCoroutine != null) {
				StopCoroutine(bulletReloadResetCoroutine);
			}
			bulletPowerUpOn = true;
			reloadTime = 0f;
			bulletReloadResetCoroutine = StartCoroutine(ResetReloadTimeAfterDelay(bulletPowerUpSpan));
		}
	}
}

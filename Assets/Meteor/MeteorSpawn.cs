using UnityEngine;

public class MeteorSpawn : MonoBehaviour
{
	public GameObject meteorPrefab;
	public float minSpawnDelay = 0.5f;
	public float maxSpawnDelay = 3f;
	public float spawnXLimit = 6f;
	public float spawnSpeedIncreaseInterval = 5f;
	public float spawnSpeedIncrease = 0.1f;

	float elapsedTime = 0f;


	void Start()
	{
		Spawn();
	}


	void Update()
	{
		// Keeping track of time for bullet firing
		elapsedTime += Time.deltaTime;

		if (elapsedTime > spawnSpeedIncreaseInterval)  {
			if (maxSpawnDelay > minSpawnDelay) {
				maxSpawnDelay = maxSpawnDelay - spawnSpeedIncrease;
			}
			elapsedTime = 0;
		}
	}

	void Spawn()
	{
		// Create a meteor at a random x position
		float random = Random.Range(-spawnXLimit, spawnXLimit);
		Vector3 spawnPos = transform.position + new Vector3(random, 0f, 0f);
		GameObject meteor = Instantiate(meteorPrefab, spawnPos, Quaternion.identity);
		int meteorNumber = Random.Range(1, 8);
		if (meteorNumber == 3) {
			meteor.transform.localScale = new Vector3(2f, 2f, 1f);
			MeteorMover mm = meteor.GetComponent<MeteorMover>();
			mm.health = 3;
		}

		Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));
	}
}

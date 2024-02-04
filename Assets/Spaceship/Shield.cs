using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // public GameObject explosionEffectPrefab;
    // void OnCollisionEnter2D(Collision2D other)
    void OnTriggerEnter2D(Collider2D other)
	{
        // print("tag: " + other.gameObject.tag);
        // print("name: " + other.gameObject.name);
        if (other.gameObject.tag == "Meteor") {
            gameObject.SetActive(false); // Deactivate shield
            MeteorMover meteor = other.gameObject.GetComponent<MeteorMover>();
			meteor.GetHit(false); // hit the meteor
            // Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity); // meteor explosion
            // Destroy(other.gameObject); // Destroy the meteor
        }
	}

    public void ActivateShield() {
        gameObject.SetActive(false);
    }
}

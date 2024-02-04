using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D other)
	{
		Destroy(other.gameObject);
	}
}

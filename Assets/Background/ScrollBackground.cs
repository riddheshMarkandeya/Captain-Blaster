using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
	public float speed = -2f;
	public float lowerYValue = -20f;
	public float upperYValue = 40;

	void Update()
	{
		transform.Translate(0f, speed * Time.deltaTime, 0f);
		if (transform.position.y <= lowerYValue)
		{
			transform.Translate(0f, upperYValue, 0f);
		}
	}
}

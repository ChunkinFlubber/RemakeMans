using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
	[SerializeField]
	float waitTime = 0.2f;
	float time = 0.0f;
	void Update()
	{
		time += Time.deltaTime;
		if (time >= waitTime)
		{
			float randomSinX = Mathf.Sin(Time.time * Random.Range(-10, 10));
			float randomSinY = Mathf.Sin(Time.time * Random.Range(-10, 10));
			Vector3 rndSinVec = new Vector3(randomSinX, randomSinY, 0);
			transform.localPosition = rndSinVec * Time.deltaTime * Random.Range(-20, 20);
		}
    }

	private void OnEnable()
	{
		time = 0.0f;
		transform.localPosition = Vector3.zero;
	}
}
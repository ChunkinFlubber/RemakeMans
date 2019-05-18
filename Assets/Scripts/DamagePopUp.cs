using UnityEngine;
using TMPro;

public class DamagePopUp : MonoBehaviour
{
	[SerializeField]
	TextMeshPro TextMesh = null;

	Vector3 Velocity = Vector3.zero;
	float Gravity = -10.0f;
	float MaxTimeOnScreen = 1.25f;
	float CurrentTimeOnScreen = 0.0f;

	void OnEnable()
    {
		transform.localScale = new Vector3(1, 1, 1);
		Velocity = new Vector3(Random.Range(-1, 1), Random.Range(1, 3), Random.Range(-1, 1)).normalized;
    }

    void FixedUpdate()
    {
		Velocity.y += Gravity * Time.deltaTime;

		float percentTime = CurrentTimeOnScreen / MaxTimeOnScreen;
		transform.localScale = new Vector3(percentTime,percentTime,percentTime);

		CurrentTimeOnScreen += Time.deltaTime;
		if(CurrentTimeOnScreen >= MaxTimeOnScreen)
		{
			//ReturnMe();
		}
    }
}
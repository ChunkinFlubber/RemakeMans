using UnityEngine;
using TMPro;

public class DamagePopUp : MonoBehaviour
{
	[SerializeField]
	TextMeshPro TextMesh = null;

	Vector3 Velocity = Vector3.zero;
	float Gravity = -10.0f;
	float MaxTimeOnScreen = 1.15f;
	float CurrentTimeOnScreen = 0.0f;

	public delegate void DamagePopUpEvent(DamagePopUp dp);

	public DamagePopUpEvent DestroyTime = delegate { };

	public void SetDamage(bool isCrit = false, int amount = 10, Color? color = null)
	{
		gameObject.SetActive(true);

		TextMesh.text = amount.ToString();
		if (!isCrit)
		{
			TextMesh.color = color ?? Color.white;
			TextMesh.outlineWidth = 0.0f;
		}
		else
		{
			TextMesh.color = color ?? Color.yellow;
			TextMesh.outlineColor = Color.magenta;
			TextMesh.outlineWidth = 0.1f;
		}

		CurrentTimeOnScreen = 0.0f;
		transform.localScale = new Vector3(1, 1, 1);
		Velocity = new Vector3(Random.Range(-3, 3), Random.Range(4, 6), Random.Range(2, 4));
	}

    void FixedUpdate()
    {
		CurrentTimeOnScreen += Time.deltaTime;

		Velocity.y += Gravity * Time.deltaTime;

		float percentTime = 1.0f - (CurrentTimeOnScreen / MaxTimeOnScreen);
		transform.localScale = new Vector3(percentTime,percentTime,percentTime);

		transform.Translate(Velocity * Time.deltaTime);

		if(CurrentTimeOnScreen >= MaxTimeOnScreen)
		{
			DestroyTime(this);
		}
    }
}
using UnityEngine;

[CreateAssetMenu(fileName = "New Damage Type", menuName = "DamageType")]
public class DamageType : ScriptableObject
{
	[SerializeField]
	public Color DamageColor = Color.white;
}

using UnityEngine;

[CreateAssetMenu(fileName = "New Damage Type", menuName = "Damage Type")]
public class DamageType : ScriptableObject
{
	[SerializeField]
	protected float _EffectChance = 0.2f;
	public float EffectChance { get => _EffectChance; protected set { _EffectChance = value; } }
	[SerializeField]
	protected float _EffectDamage = 2.0f;
	public float EffectDamage { get => _EffectDamage; set { _EffectDamage = value; } }
	[SerializeField]
	protected DamageEffect _Effect = null;
	public DamageEffect Effect { get => _Effect; protected set { _Effect = value; } }

	public bool Apply()
	{
		Effect.SetDamage(EffectDamage);
		return Random.Range(0.0f, 1.0f) < EffectChance;
	}

	public Color GetColor()
	{
		return Effect.DamageColor;
	}
}

using UnityEngine;

[CreateAssetMenu(menuName = "StatusEffect/ROFStatusEffect", fileName = "ROF Status Effect")]
public class ROFStatusEffect : StatusEffect
{
	[SerializeField]
	private float ROFMultiplyer = 0.25f;
	[SerializeField]
	private float AdditionalPerStack = 0.25f;

	public override void Init(StatsSystem master)
	{
		base.Init(master);
	}

	public override void Effect(ref float value)
	{
		base.Effect(ref value);
		value += ROFMultiplyer + ((Stack - 1) * AdditionalPerStack);
	}

	public override void AddStack()
	{
		base.AddStack();
	}

	public override void RemoveStack()
	{
		base.RemoveStack();
	}

	public override void Destroy()
	{

	}
}

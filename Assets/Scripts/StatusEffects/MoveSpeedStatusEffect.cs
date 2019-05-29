using UnityEngine;

[CreateAssetMenu(menuName = "Mutations/SpeedMutation", fileName = "SpeedMutation")]
public class MoveSpeedStatusEffect : StatusEffect
{
    [SerializeField]
	private float SpeedMultiplyer = 1.25f;
    [SerializeField]
	private float AdditionalPerStack = 0.25f;

    public override void Init(StatsSystem master)
	{
        base.Init(master);
    }

	public override void Effect(ref float value)
	{
		base.Effect(ref value);
		value += SpeedMultiplyer + (AdditionalPerStack * (Stack - 1));
	}

	public override void AddStack()
    {
        ++Stack;
    }

    public override void RemoveStack()
    {
		--Stack;
    }

    public override void Destroy()
	{

	}
}

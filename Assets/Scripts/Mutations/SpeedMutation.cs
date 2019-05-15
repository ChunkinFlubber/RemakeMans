using UnityEngine;

[CreateAssetMenu(menuName = "Mutations/SpeedMutation", fileName = "SpeedMutation")]
public class SpeedMutation : Mutation
{
    [SerializeField]
	private float SpeedMultiplyer = 1.25f;
    [SerializeField]
	private float AdditionalPerStack = 0.25f;

	private CharacterMovementSettings MoveSettings = null;

    override public void Init(MutationSystem master)
	{
        base.Init(master);
		MoveSettings = Master.MoveSystem.MovementData;
        MoveSettings.MoveSpeedMutated = MutateSpeed(MoveSettings.BaseMoveSpeed);
    }

	public float MutateSpeed(float speed) => speed * (SpeedMultiplyer + (AdditionalPerStack * (Stack - 1)));

	public override void AddStack()
    {
        ++Stack;
        MoveSettings.MoveSpeedMutated = MutateSpeed(MoveSettings.BaseMoveSpeed);
    }

    public override void RemoveStack()
    {
		--Stack;
		MoveSettings.MoveSpeedMutated = MutateSpeed(MoveSettings.BaseMoveSpeed);
    }

    public override void Destroy()
	{

	}
}

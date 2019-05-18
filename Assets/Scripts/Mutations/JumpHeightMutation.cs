using UnityEngine;

[CreateAssetMenu(menuName = "Mutations/JumpHeightMutation", fileName = "JumpHeightMutation")]
public class JumpHeightMutation : Mutation
{
	[SerializeField]
	private float HeightPerStack = 0.25f;

	private CharacterMovementSettings MoveSettings = null;
	public override void Init(MutationSystem master)
	{
		base.Init(master);
		MoveSettings = Master.MoveSystem.MovementData;
		MoveSettings.JumpHeightMutated = MoveSettings.BaseJumpHeight + Stack * HeightPerStack;
	}

	public override void AddStack()
	{
		base.AddStack();
		MoveSettings.JumpHeightMutated = MoveSettings.BaseJumpHeight + Stack * HeightPerStack;
	}

	public override void RemoveStack()
	{
		base.RemoveStack();
		MoveSettings.JumpHeightMutated = MoveSettings.BaseJumpHeight + Stack * HeightPerStack;
	}

	public override void Destroy()
	{
		base.Destroy();

	}
}

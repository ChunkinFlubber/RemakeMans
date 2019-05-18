using UnityEngine;

[CreateAssetMenu(menuName = "Mutations/JumpCountMutation", fileName = "JumpCountMutation")]
public class JumpCountMutation : Mutation
{
	[SerializeField]
	private float CountPerStack = 1;

	private CharacterMovementSettings MoveSettings = null;
	public override void Init(MutationSystem master)
	{
		base.Init(master);
		MoveSettings = Master.MoveSystem.MovementData;
		MoveSettings.JumpCountMutated = (int)(MoveSettings.BaseJumpCount + Stack * CountPerStack);
	}

	public override void AddStack()
	{
		base.AddStack();
		MoveSettings.JumpCountMutated = (int)(MoveSettings.BaseJumpCount + Stack * CountPerStack);
	}

	public override void RemoveStack()
	{
		base.RemoveStack();
		MoveSettings.JumpCountMutated = (int)(MoveSettings.BaseJumpCount + Stack * CountPerStack);
	}

	public override void Destroy()
	{
		base.Destroy();

	}
}

using UnityEngine;

[CreateAssetMenu(menuName = "Mutations/ROFMutation", fileName = "ROFMutation")]
public class ROFMutation : Mutation
{
	[SerializeField]
	private float ROFMultiplyer = 1.25f;
	[SerializeField]
	private float AdditionalPerStack = 0.25f;

	private Weapon WeaponMans = null;
	private float InitROF = 0;

	override public void Init(MutationSystem master)
	{
		base.Init(master);
		WeaponMans = master.WeapSys;
		InitROF = WeaponMans.ROF;
		RecalculateROF();
	}

	void RecalculateROF()
	{
		WeaponMans.ROF = InitROF * (ROFMultiplyer + AdditionalPerStack * (Stack - 1));
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

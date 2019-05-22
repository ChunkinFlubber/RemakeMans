using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Mutations/ROFMutation", fileName = "ROFMutation")]
public class ROFMutation : Mutation
{
	[SerializeField]
	private float ROFMultiplyer = 1.25f;
	[SerializeField]
	private float AdditionalPerStack = 0.25f;

	private WeaponSlot WeapSlot = null;
	private float InitROF = 0;

	override public void Init(MutationSystem master)
	{
		base.Init(master);
		WeapSlot = master.WeapSys;
		WeapSlot.WeaponHandled += NewWeapon;
		if(WeapSlot.SlottedWeapon)
		{
			InitROF = WeapSlot.SlottedWeapon.ROF;
			RecalculateROF();
		}
	}

	private void NewWeapon(bool pickedUp, Weapon weapon)
	{
		if (weapon == null) return;
		if(pickedUp)
		{
			InitROF = weapon.ROF;
			RecalculateROF();
		}
		else
		{
			weapon.ROF = InitROF;
		}
	}

	void RecalculateROF()
	{
		WeapSlot.SlottedWeapon.ROF = InitROF * (ROFMultiplyer + AdditionalPerStack * (Stack - 1));
	}

	public override void AddStack()
	{
		++Stack;
		RecalculateROF();
	}

	public override void RemoveStack()
	{
		--Stack;
		RecalculateROF();
	}

	public override void Destroy()
	{

	}
}

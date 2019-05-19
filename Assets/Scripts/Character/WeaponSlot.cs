using UnityEngine;
using UnityEngine.Experimental.Input;

public class WeaponSlot : MonoBehaviour
{
	MasterInputs Input;
	bool isFiring = false;
	bool isSlotted = false;

	[SerializeField]
	Transform _SlotPosition = null;
	public Transform SlotPosition { get => _SlotPosition; private set { _SlotPosition = value; } }

	[SerializeField]
	Weapon _SlottedWeapon = null;
	public Weapon SlottedWeapon { get => _SlottedWeapon; private set { _SlottedWeapon = value; } }


	public delegate void FireEvent(Projectile projectile);

	public FireEvent Fired = delegate { };

	public void Init(MasterInputs input)
	{
		Input = input;

		Input.Character.Fire.Enable();
		Input.Character.Fire.performed += Fire;
		Input.Character.Fire.cancelled += Fire;
	}

	public void Fire(InputAction.CallbackContext context)
	{
		isFiring = !isFiring;
	}

	public bool SlotWeapon(Weapon weapon)
	{
		if(SlottedWeapon == null)
		{
			SlottedWeapon = weapon;
			//TODO: Replace with lerp to character
			isSlotted = true;
			weapon.transform.parent = SlotPosition;
			return true;
		}
		return false;
	}

	public void DiscardWeapon(Weapon weapon)
	{
		if(SlottedWeapon && isSlotted)
		{
			isSlotted = false;
			weapon.transform.parent = null;
			//TODO: Throw Weapon
		}
	}
}

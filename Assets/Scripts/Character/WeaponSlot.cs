using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSlot : MonoBehaviour
{
	bool isFiring = false;
	bool isSlotted = false;

	[SerializeField]
	Transform _SlotPosition = null;
	public Transform SlotPosition { get => _SlotPosition; private set { _SlotPosition = value; } }

	[SerializeField]
	Weapon _SlottedWeapon = null;
	public Weapon SlottedWeapon { get => _SlottedWeapon; private set { _SlottedWeapon = value; } }

	public delegate void WeaponHandledEvent(bool pickedUp, Weapon weapon);
	public WeaponHandledEvent WeaponHandled = delegate { };


	private void Start()
	{
		
	}

	public void Fire(InputAction.CallbackContext context)
	{
		isFiring = !isFiring;
		if(SlottedWeapon)
		{
			SlottedWeapon.SetFire(isFiring);
		}
	}

	public bool SlotWeapon(Weapon weapon)
	{
		if(SlottedWeapon == null)
		{
			SlottedWeapon = weapon;
			weapon.PickedUp(gameObject);
			//TODO: Replace with lerp to character or some pick up animation
			weapon.transform.parent = SlotPosition;
			weapon.transform.localPosition = Vector3.zero;
			weapon.transform.localRotation = Quaternion.identity;
			isSlotted = true;
			return true;
		}
		return false;
	}

	public void DiscardWeapon()
	{
		if(SlottedWeapon && isSlotted)
		{
			SlottedWeapon.transform.parent = null;
			SlottedWeapon.Dropped();
			SlottedWeapon = null;
			//TODO: Throw Weapon
			isSlotted = false;
		}
	}
}
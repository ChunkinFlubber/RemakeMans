using UnityEngine;

[RequireComponent(typeof(CharacterMovementSystem))]
[RequireComponent(typeof(LevelSystem))]
[RequireComponent(typeof(MutationSystem))]
[RequireComponent(typeof(WeaponSlot))]
public class PlayerController : MonoBehaviour
{
    MasterInputs InputMan;
    CharacterMovementSystem MovementSys;
    LevelSystem LevelSys;
    MutationSystem MutSys;
    WeaponSlot WeaponSlot;

    void Awake()
    {
        InputMan = new MasterInputs();

        MovementSys = GetComponent<CharacterMovementSystem>();

        LevelSys = GetComponent<LevelSystem>();

        MutSys = GetComponent<MutationSystem>();

        WeaponSlot = GetComponent<WeaponSlot>();
    }

    void Start()
    {
		SetupInput();
    }

	private void SetupInput()
	{
		MovementInputSetup();
		WeaponSlotInputSetup();
	}
	private void MovementInputSetup()
	{
		InputMan.Character.Movement.Enable();
		InputMan.Character.Movement.performed += MovementSys.MoveInput;
		InputMan.Character.Movement.canceled += MovementSys.MoveInput;

		InputMan.Character.Jump.Enable();
		InputMan.Character.Jump.performed += MovementSys.Jump;

		InputMan.Character.Look.Enable();
		InputMan.Character.Look.performed += MovementSys.LookAround;
	}
	private void WeaponSlotInputSetup()
	{
		InputMan.Character.Fire.Enable();
		InputMan.Character.Fire.performed += WeaponSlot.Fire;
		InputMan.Character.Fire.canceled += WeaponSlot.Fire;
	}

	void Update()
    {
        
    }

    private void OnDestroy() 
    {
		InputDestroy();
	}

	private void InputDestroy()
	{
		MovementInputDestroy();
		WeaponSlotInputDestroy();
	}
	private void MovementInputDestroy()
	{
		InputMan.Character.Movement.Disable();
		InputMan.Character.Look.Disable();
		InputMan.Character.Jump.Disable();
		InputMan.Character.Movement.performed -= MovementSys.MoveInput;
		InputMan.Character.Movement.canceled -= MovementSys.MoveInput;
		InputMan.Character.Jump.performed -= MovementSys.Jump;
		InputMan.Character.Look.performed -= MovementSys.LookAround;
	}
	private void WeaponSlotInputDestroy()
	{
		InputMan.Character.Fire.Disable();
		InputMan.Character.Fire.performed -= WeaponSlot.Fire;
		InputMan.Character.Fire.canceled -= WeaponSlot.Fire;
	}
}
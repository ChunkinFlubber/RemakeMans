﻿using System;
using UnityEngine;
using UnityEngine.Experimental.Input;

public class CharacterMovementSystem : MonoBehaviour
{
    [SerializeField]
    public CharacterMovementSettings MovementData;
    MasterInputs Input;
    CharacterController Controller;
    Camera Cam;
    [SerializeField]
    public Transform GroundChecker = null;
    bool isGrounded = false;
    bool prevGrounded = false;
    bool hasCheckedGroundThisFrame = false;
	int CurrentJumpCount = 0;

    public delegate void MovementEvent();
    public delegate void MutationEvent(ref float mutValue);

    public MovementEvent Jumped = delegate{};
    public MovementEvent Landed = delegate{};

    public MutationEvent MutateMoveSpeed = delegate{};
    public MutationEvent MutateJumpHeight = delegate{};

    public void Init(MasterInputs input, CharacterController controller, Camera cam)
    {
        Input = input;
        Controller = controller;
        Cam = cam;

        MovementData.Setup();

        MovementData.Velocity = Vector3.zero;

        SetupInput();
    }

    private void SetupInput()
    {
        Input.Character.Movement.Enable();
        Input.Character.Movement.performed += MoveInput;
        Input.Character.Movement.cancelled += MoveInput;

        Input.Character.Jump.Enable();
        Input.Character.Jump.performed += Jump;

        Input.Character.Look.Enable();
        Input.Character.Look.performed += LookAround;
    }

    private void Update()
    {
        InputMovementTick();
        OtherMovementTick();
        hasCheckedGroundThisFrame = false;
    }

    private void InputMovementTick()
    {
        Vector3 Heading = Controller.transform.forward * MovementData.InputMoveVector.z + Controller.transform.right * MovementData.InputMoveVector.x;
        float MoveSpeed = MovementData.MoveSpeed;
        
        if (!CheckGorund())
        {
            Heading *= MovementData.AirControl;
            MoveSpeed *= 0.5f;
        }

        Heading *= MovementData.Acceleration * Time.deltaTime;

        MovementData.InputVelocity += Heading;

        MovementData.InputVelocity = Vector3.ClampMagnitude(MovementData.InputVelocity, MoveSpeed);

        Controller.Move(MovementData.InputVelocity * Time.deltaTime);

        DragAndFriction(ref MovementData.InputVelocity);
    }

    private void OtherMovementTick()
    {
        MovementData.Velocity.y += MovementData.Gravity * Time.deltaTime;

        Controller.Move(MovementData.Velocity * Time.deltaTime);

        DragAndFriction(ref MovementData.Velocity);

        if (CheckGorund())
        {
            MovementData.Velocity.y = 0;
        }
    }

    public void LookAround(InputAction.CallbackContext context)
    {
        Vector2 delta = context.ReadValue<Vector2>();
        delta *= 0.01f;
        MovementData.MouseLook += delta * MovementData.Sens;
        MovementData.MouseLook.y = Mathf.Clamp(MovementData.MouseLook.y, -89.9f, 89.9f);
        Controller.transform.localRotation = Quaternion.AngleAxis(MovementData.MouseLook.x, Controller.transform.up);
        Cam.transform.localRotation = Quaternion.AngleAxis(-MovementData.MouseLook.y, Vector3.right);
		DebugUIScript.Instance.SetText(MovementData.MouseLook.ToString());
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if((CheckGorund() && MovementData.Velocity.y <= 0.0f) || (CurrentJumpCount < MovementData.JumpCount - 1))
        {
            float jumpHeight = MovementData.JumpHeight;
            MovementData.Velocity.y = Mathf.Sqrt(jumpHeight * -2f * MovementData.Gravity);
            Jumped();
            isGrounded = false;
			++CurrentJumpCount;
        }
    }

    public void MoveInput(InputAction.CallbackContext context)
    {
        Vector2 axis = context.ReadValue<Vector2>();
        MovementData.InputMoveVector.x = axis.x;
        MovementData.InputMoveVector.z = axis.y;
    }

    public void AddMoveVector(Vector3 movement)
    {
        MovementData.InputMoveVector = movement;
    }


    private void DragAndFriction(ref Vector3 velocity)
    {
        velocity.x /= 1 + MovementData.Drag.x * Time.deltaTime;
        velocity.y /= 1 + MovementData.Drag.y * Time.deltaTime;
        velocity.z /= 1 + MovementData.Drag.z * Time.deltaTime;
        if(CheckGorund())
        {
            velocity.x /= 1 + MovementData.Friction.x * Time.deltaTime;
            velocity.y /= 1 + MovementData.Friction.y * Time.deltaTime;
            velocity.z /= 1 + MovementData.Friction.z * Time.deltaTime;
        }
    }

    private bool CheckGorund()
    {
        if (hasCheckedGroundThisFrame)
        {
            return isGrounded;
        }
        else
        {
            prevGrounded = isGrounded;
        }
        isGrounded = FindGround();
        hasCheckedGroundThisFrame = true;
        if (!prevGrounded && isGrounded)
        {
            Landed();
			CurrentJumpCount = 0;
        }
        return isGrounded;
    }

    private bool FindGround()
    {
        bool hit = Physics.CheckSphere(GroundChecker.position, MovementData.GroundDistance, MovementData.Ground, QueryTriggerInteraction.Ignore);
        if (hit)
        {
            RaycastHit rhit;
            Ray ray = new Ray(GroundChecker.position, new Vector3(0, -MovementData.GroundDistance, 0));
            Physics.Raycast(ray, out rhit);
            if (Vector3.Dot(Vector3.up, rhit.normal) > 0.2f)
            {
                return true;
            }
        }
        return false;
    }

    private void OnDestroy()
    {
        Input.Character.Movement.performed -= MoveInput;
        Input.Character.Movement.cancelled -= MoveInput;
        Input.Character.Jump.performed -= Jump;
        Input.Character.Look.performed -= LookAround;
        Input.Character.Movement.Disable();
        Input.Character.Look.Disable();
        Input.Character.Jump.Disable();
    }
}
using System;
using UnityEngine;
using UnityEngine.Experimental.Input;

public class CharacterMovementSystem : MonoBehaviour
{
    CharacterMovementSettings MovementData;
    MasterInputs Input;
    CharacterController Controller;
    Camera Cam;
    bool isGrounded = false;
    bool prevGrounded = false;
    bool hasCheckedGroundThisFrame = false;

    public delegate void MovementEvent();
    public delegate void MutationEvent(ref float mutValue);

    public MovementEvent Jumped = delegate{};
    public MovementEvent Landed = delegate{};

    public MutationEvent MutateMoveSpeed = delegate{};

    public void Init(CharacterMovementSettings data, MasterInputs input, CharacterController controller, Camera cam)
    {
        Input = input;
        MovementData = data;
        Controller = controller;
        Cam = cam;

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

        MutateMoveSpeed(ref MoveSpeed);

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
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(CheckGorund() && MovementData.Velocity.y <= 0.0f)
        {
            MovementData.Velocity.y = Mathf.Sqrt(MovementData.JumpHeight * -2f * MovementData.Gravity);
            Jumped();
            isGrounded = false;
        }
    }

    public void MoveInput(InputAction.CallbackContext context)
    {
        Vector2 axis = context.ReadValue<Vector2>();
        MovementData.InputMoveVector.x = axis.x;
        MovementData.InputMoveVector.z = axis.y;
    }
    //Used for movement
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
        if(hasCheckedGroundThisFrame)
        {
            return isGrounded;
        }
        else
        {
            prevGrounded = isGrounded;
        }
        isGrounded = Physics.CheckSphere(MovementData.GroundChecker.position, MovementData.GroundDistance, MovementData.Ground, QueryTriggerInteraction.Ignore);
        hasCheckedGroundThisFrame = true;
        if(!prevGrounded && isGrounded)
        {
            Landed();
        }
        return isGrounded;
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
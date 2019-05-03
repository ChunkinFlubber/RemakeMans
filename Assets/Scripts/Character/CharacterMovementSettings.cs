using UnityEngine;

[CreateAssetMenu(menuName = "Character/Settings/Movement", fileName = "MovementData")]
public class CharacterMovementSettings : ScriptableObject
{
    [Header("Movement")]
    [SerializeField]
    float _BaseMoveSpeed = 10.0f;
    public float BaseMoveSpeed { get => _BaseMoveSpeed; }
    [SerializeField]
    float _Acceleration = 58.0f;
    public float Acceleration { get => _Acceleration; }
    [SerializeField]
    float _BaseJumpHeight = 3.0f;
    float BaseJumpHeight { get => _BaseJumpHeight; }
    [SerializeField]
    int _BaseJumpCount = 1;
    int BaseJumpCount { get => _BaseJumpCount; }

    [SerializeField]
    float _MoveSpeedAdjust = 1.3f;
    [SerializeField]
    float _JumpHeightAdjust = 1.0f;
    [SerializeField]
    int _JumpCountAdjust = 0;

    float MoveSpeedMod = 1;
    float JumpHeightMod = 1;
    int JumpCoundMod = 0;

    public float MoveSpeed { get{ return MoveSpeedMod * BaseMoveSpeed; } }
    public float JumpHeight {  get{ return JumpHeightMod * BaseJumpHeight; } }
    public float JumpCount {  get{ return JumpCoundMod + BaseJumpCount; } }

    [SerializeField]
    float _AirControl = 0.2f;
    public float AirControl {get { return _AirControl; } }

    [Header("Physics")]
    [SerializeField]
    float _Gravity = -9.8f;
    public float Gravity {get { return _Gravity; } }
    [SerializeField]
    Vector3 _Drag = Vector3.zero;
    public Vector3 Drag {get { return _Drag; } }
    [SerializeField]
    Vector3 _Friction = Vector3.zero;
    public Vector3 Friction {get { return _Friction; } }


    [HideInInspector]
    public Vector3 InputMoveVector = Vector3.zero;
    [HideInInspector]
    public Vector3 Velocity = Vector3.zero;
    [HideInInspector]
    public Vector3 InputVelocity = Vector3.zero;

    [SerializeField]
    public LayerMask Ground;
    [SerializeField]
    public float GroundDistance = 0.035f;

    [SerializeField]
    float _Sens = 2.5f;
    public float Sens { get => _Sens; set => _Sens = value; }
    public Vector2 MouseLook;

    public void HandleLevelUp()
    {
        _BaseMoveSpeed += _MoveSpeedAdjust;
        _BaseJumpHeight += _JumpHeightAdjust;
        _BaseJumpCount += _JumpCountAdjust;
    }
}
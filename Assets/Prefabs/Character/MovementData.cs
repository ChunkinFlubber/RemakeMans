using UnityEngine;

public class MovementData
{
    [Header("Movement")]
    [SerializeField]
    float _BaseMoveSpeed = 10.0f;
    public float BaseMoveSpeed { get => _BaseMoveSpeed; }
    [SerializeField]
    [Tooltip("Multiplied by Movespeed for adjusable acceleration")]
    float _Acceleration = 6.0f;
    public float Acceleration { get => _Acceleration * MoveSpeed; }
    [SerializeField]
    float _BaseJumpHeight = 3.0f;
    float BaseJumpHeight { get => _BaseJumpHeight; }
    [SerializeField]
    int _BaseJumpCount = 1;
    int BaseJumpCount { get => _BaseJumpCount; }

    public float MoveSpeedMutated = 10.0f;
    public float JumpHeightMutated = 3.0f;
    public int JumpCoundMutated = 1;

    public float MoveSpeed { get{ return MoveSpeedMutated; } }
    public float JumpHeight {  get{ return JumpHeightMutated; } }
    public float JumpCount {  get{ return JumpCoundMutated; } }

    [Header("LevelUp Adjustments")]
    [SerializeField]
    float _MoveSpeedAdjust = 1.3f;
    [SerializeField]
    float _JumpHeightAdjust = 1.0f;
    [SerializeField]
    int _JumpCountAdjust = 0;

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
    [SerializeField]
    float _AirControl = 0.2f;
    public float AirControl {get { return _AirControl; } }

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
    public Vector2 MouseLook = Vector2.zero;

    public void Setup()
    {
        MoveSpeedMutated = BaseMoveSpeed;
        JumpHeightMutated = BaseJumpHeight;
        JumpCoundMutated = BaseJumpCount;
    }

    public void HandleLevelUp()
    {
        _BaseMoveSpeed += _MoveSpeedAdjust;
        _BaseJumpHeight += _JumpHeightAdjust;
        _BaseJumpCount += _JumpCountAdjust;
    }
}

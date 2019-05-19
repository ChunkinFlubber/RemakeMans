using UnityEngine;

[RequireComponent(typeof(CharacterMovementSystem))]
[RequireComponent(typeof(LevelSystem))]
[RequireComponent(typeof(MutationSystem))]
//[RequireComponent(typeof(HealthSystem))]
public class Character : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField]
    Camera MyCamera = null;

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
        MovementSys.Init(InputMan, GetComponent<CharacterController>(), MyCamera);
        WeaponSlot.Init(InputMan);
    }

    void Update()
    {
        
    }

    private void OnDestroy() 
    {
        
    }
}
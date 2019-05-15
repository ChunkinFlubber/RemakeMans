using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(CharacterMovementSystem))]
[RequireComponent(typeof(LevelSystem))]
[RequireComponent(typeof(MutationSystem))]
public class Character : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField]
    Camera MyCamera = null;

    MasterInputs InputMan;
    CharacterMovementSystem MovementSys;
    LevelSystem LevelSys;
    MutationSystem MutSys;
    Weapon WeaponSys;

    void Awake()
    {
        InputMan = new MasterInputs();

        MovementSys = GetComponent<CharacterMovementSystem>();

        LevelSys = GetComponent<LevelSystem>();

        MutSys = GetComponent<MutationSystem>();

        WeaponSys = GetComponent<Weapon>();
    }

    void Start()
    {
        MovementSys.Init(InputMan, GetComponent<CharacterController>(), MyCamera);
        WeaponSys.Init(InputMan);
    }

    void Update()
    {
        
    }

    private void OnDestroy() 
    {
        
    }
}
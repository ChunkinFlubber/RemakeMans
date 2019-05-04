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
    CharacterMovementSystem Movement;
    LevelSystem LevelSys;
    MutationSystem MutSys;

    void Awake()
    {
        InputMan = new MasterInputs();

        Movement = GetComponent<CharacterMovementSystem>();

        LevelSys = GetComponent<LevelSystem>();

        MutSys = GetComponent<MutationSystem>();
    }

    void Start()
    {
        Movement.Init(InputMan, GetComponent<CharacterController>(), MyCamera);
    }

    void Update()
    {
        
    }

    private void OnDestroy() 
    {
        
    }
}
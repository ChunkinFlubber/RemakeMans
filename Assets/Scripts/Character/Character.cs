using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField]
    CharacterMovementSettings MovementSettings = null;
    [SerializeField]
    Camera MyCamera = null;
    [SerializeField]
    Transform FeetPosition = null;

    MasterInputs InputMan;
    CharacterMovementSystem Movement;
    LevelSystem LevelSys;

    void Awake()
    {
        InputMan = new MasterInputs();

        MovementSettings.GroundChecker = FeetPosition;
        Movement = GetComponent<CharacterMovementSystem>();
        Movement.Init(MovementSettings, InputMan, GetComponent<CharacterController>(), MyCamera);

        LevelSys = GetComponent<LevelSystem>();
    }

    void Update()
    {
        
    }

    private void OnDestroy() 
    {
        
    }
}
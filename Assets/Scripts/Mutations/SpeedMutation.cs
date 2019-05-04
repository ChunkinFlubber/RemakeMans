using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mutations/SpeedMutation", fileName = "SpeedMutation")]
public class SpeedMutation : Mutation
{
    [SerializeField]
    float SpeedMultiplyer = 1.25f;
    [SerializeField]
    float AdditionalPerStack = 0.25f;

    CharacterMovementSettings MoveSettings = null;

    override public void Init(MutationSystem master)
    {
        base.Init(master);
        MoveSettings = Master.MoveSystem.MovementData;
        MoveSettings.MoveSpeedMutated = MutateSpeed(MoveSettings.BaseMoveSpeed);
    }

    public float MutateSpeed(float speed)
    {
        return speed * (SpeedMultiplyer + (AdditionalPerStack * (Stack - 1)));
    }

    override public void AddStack()
    {
        ++Stack;
        MoveSettings.MoveSpeedMutated = MutateSpeed(MoveSettings.BaseMoveSpeed);
    }

    override public void RemoveStack()
    {
        --Stack;
        MoveSettings.MoveSpeedMutated = MutateSpeed(MoveSettings.BaseMoveSpeed);
    }

    override public void Destroy()
    {
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutationSystem : MonoBehaviour
{
    Dictionary<Type, Mutation> Mutations;
    public int NumOfMutations {get { return Mutations.Count; } private set { NumOfMutations = value; } }

    public Character MyCharacter { get; private set; }
    public CharacterMovementSystem MoveSystem { get; private set; }
    public LevelSystem Levels { get; private set; }

    void Start()
    {
        MyCharacter = GetComponent<Character>();
        MoveSystem = GetComponent<CharacterMovementSystem>();
        Levels = GetComponent<LevelSystem>();
        Mutations = new Dictionary<Type, Mutation>();
    }

    void Update()
    {
        foreach (KeyValuePair<Type, Mutation> mut in Mutations)
        {
            if(mut.Value.TickEnabled)
            {
                mut.Value.Tick();
            }
        }
    }

    void OnDestroy()
    {
        foreach (KeyValuePair<Type, Mutation> mut in Mutations)
        {
            mut.Value.Destroy();
        }
    }
}

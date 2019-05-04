using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutationSystem : MonoBehaviour
{
    SphereCollider PickUpDetector = null;

    Dictionary<Type, Mutation> Mutations;
    public int NumOfMutations {get { return Mutations.Count; } private set { NumOfMutations = value; } }

    public Character MyCharacter { get; private set; }
    public CharacterMovementSystem MoveSystem { get; private set; }
    public LevelSystem Levels { get; private set; }

    void Start()
    {
        PickUpDetector = gameObject.AddComponent<SphereCollider>();
        PickUpDetector.radius = 1.25f;
        PickUpDetector.isTrigger = true;

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

    void OnTriggerEnter(Collider e)
    {
        MutationAsset mutA = e.GetComponent<MutationAsset>();
        if(mutA != null)
        {
            Mutation mut = mutA.GetMutation();
            if(mut != null)
            {
                //Add
                if(Mutations.ContainsKey(mut.GetType()))
                {
                    Mutations[mut.GetType()].AddStack();
                }
                else
                {
                    Mutations.Add(mut.GetType(), mut);
                    mut.Init(this);
                }
            }
        }
        Debug.Log(e.gameObject.name);
    }

    void OnDestroy()
    {
        foreach (KeyValuePair<Type, Mutation> mut in Mutations)
        {
            mut.Value.Destroy();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutationAsset : MonoBehaviour
{
    [SerializeField]
    Mutation MyMutation = null;

    Vector3 StartPosition;
    void Start()
    {
        StartPosition = transform.position;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position = StartPosition + new Vector3(0,Mathf.Sin(Time.time) * 0.15f,0);
        //transform.Rotate(0,1,0);
    }

    public Mutation GetMutation()
    {
        Destroy(gameObject);
        return MyMutation;
    }
}

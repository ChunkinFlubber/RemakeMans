using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    float LifeTime;
    float CurrLifeTime;
    float Speed;
    Vector3 Direction;
    Rigidbody Body;
    TrailRenderer Trail;

    void Awake()
    {
        Body = GetComponent<Rigidbody>();
        Trail = GetComponentInChildren<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Direction * Speed * Time.deltaTime, Space.World);
        CurrLifeTime += Time.deltaTime;
        if(CurrLifeTime > LifeTime)
        {
            ProjectilePool.Instance.Return(this);
            gameObject.SetActive(false);
        }
    }

    public void Setup(Vector3 direction, float speed)
    {
        Direction = direction;
        Speed = speed;
        CurrLifeTime = 0;
        Trail.Clear();
    }
}

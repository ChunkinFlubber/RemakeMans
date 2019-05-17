﻿using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    float LifeTime;
    float CurrLifeTime;
    float Speed;
    Vector3 Direction;
    Collider Body;
    TrailRenderer Trail;
	GameObject Shooter = null;

    void Awake()
    {
        Body = GetComponent<Collider>();
		Body.enabled = false;
        Trail = GetComponentInChildren<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Direction * Speed * Time.deltaTime, Space.World);
        CurrLifeTime += Time.deltaTime;
        if(CurrLifeTime > LifeTime)
        {
			ReturnMe();
        }
    }

    public void Setup(GameObject shooter, Vector3 direction, float speed)
    {
		Shooter = shooter;
        Direction = direction;
        Speed = speed;
        CurrLifeTime = 0;
        Trail.Clear();
		Body.enabled = true;
    }

	private void ReturnMe()
	{
		ProjectilePool.Instance.Return(this);
		gameObject.SetActive(false);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.gameObject != Shooter)
		{
			Debug.Log(collision.collider.gameObject);
			ReturnMe();
		}
	}
}

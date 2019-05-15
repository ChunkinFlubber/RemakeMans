using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    public static ProjectilePool Instance { get; private set; }

    [SerializeField]
    private Projectile prefab;

    private Queue<Projectile> projectileAvailable = new Queue<Projectile>();

    private void Awake()
    {
        Instance = this;
    }

    public Projectile Get()
    {
        if (projectileAvailable.Count == 0)
        {
            return AddBall();
        }

        return projectileAvailable.Dequeue();
    }

    private Projectile AddBall()
    {
        var projectile = Instantiate(prefab);
        return projectile;
    }

    public void Return(Projectile projectile)
    {
        projectileAvailable.Enqueue(projectile);
    }
}

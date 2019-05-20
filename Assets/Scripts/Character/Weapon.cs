using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField]
	ProjectilePool ProPool = null;

	[SerializeField]
	private float _ROF = 1.35f;
	public float ROF { get => _ROF; set { _ROF = value; RoundsDelta = 1 / _ROF; } }
	[SerializeField]
    float ProjectileSpeed = 10.0f;
    [SerializeField]
    Transform MuzzleTransform = null;

	public delegate void FireEvent(Projectile projectile);

	public FireEvent Fired = delegate { };

	bool isFiring = false;
	float RoundsDelta = 0;
	float CurrentDelta = 0;

	private void Start()
	{
		RoundsDelta = 1 / ROF;
		CurrentDelta = RoundsDelta + 1f;
		if(ProPool == null)
		{
			ProPool = GetComponent<ProjectilePool>();
		}
	}

    public void SetFire(bool firing)
	{
		isFiring = firing;
	}

	private void Update()
	{
		CurrentDelta += Time.deltaTime;
		if(isFiring)
		{
			if(CurrentDelta >= RoundsDelta)
			{
				Projectile projectile = SpawnProjectile();
				CurrentDelta = 0;
				Fired(projectile);
			}
		}
	}

	private Projectile SpawnProjectile()
	{
		Projectile projectile = ProPool.Get();
		projectile.gameObject.SetActive(true);
		projectile.transform.position = MuzzleTransform.position;
		projectile.transform.rotation = MuzzleTransform.rotation;
		projectile.Setup(gameObject, MuzzleTransform.forward, ProjectileSpeed);
		projectile.ProjectileReturn += ReturnProjectile;
		return projectile;
	}

	public void ReturnProjectile(Projectile projectile)
	{
		projectile.ProjectileReturn -= ReturnProjectile;
		ProPool.ReturnObject(projectile);
	}
}
using UnityEngine;

public class Weapon : MonoBehaviour
{
	[Header("Weapon Setup")]
	[SerializeField]
	ProjectilePool ProPool = null;
    [SerializeField]
    Transform MuzzleTransform = null;
	[SerializeField]
	BoxCollider Trigger = null;
	[SerializeField]
	Rigidbody RBody = null;
	[SerializeField]
	GameObject PhysicsBodys = null;

	[Header("Weapon Base Stats")]
	[SerializeField]
	protected float BaseDamage = 10.0f;
	protected float _Damage = 0.0f;
	public float Damage { get => _Damage; protected set { _Damage = value; } }
	[SerializeField]
	private float BaseROF = 1.35f;
	private float _ROF;
	public float ROF
	{
		get
		{
			return _ROF;
		}
		set
		{
			_ROF = value;
			RoundsDelta = 1 / _ROF;
		}
	}
	[SerializeField]
    float ProjectileSpeed = 30.0f;
	[SerializeField]
	public DamageType[] DamageTypes = null;


	public delegate void FireEvent(Projectile projectile);
	public FireEvent Fired = delegate { };

	public GameObject Owner { get; private set; }
	StatsSystem OwnerStats = null;
	bool isFiring = false;
	float RoundsDelta = 0;
	float CurrentDelta = 0;

	private void Start()
	{
		Damage = BaseDamage;
		ROF = BaseROF;
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
		projectile.transform.parent = null;
		projectile.transform.position = MuzzleTransform.position;
		projectile.transform.rotation = MuzzleTransform.rotation;
		projectile.Setup(this, MuzzleTransform.forward, Damage, ProjectileSpeed);
		projectile.ProjectileReturn += ReturnProjectile;
		return projectile;
	}

	public void ReturnProjectile(Projectile projectile)
	{
		projectile.ProjectileReturn -= ReturnProjectile;
		ProPool.ReturnObject(projectile);
	}

	public void PickedUp(GameObject owner)
	{
		Owner = owner;
		OwnerStats = Owner.GetComponent<StatsSystem>();
		if(OwnerStats)
		{
			OwnerStats.StatusEffectEvent += StatsChange;
			StatsCheck();
		}
		PhysicsBodys.SetActive(false);
		RBody.isKinematic = true;
		Trigger.enabled = false;
	}

	public void Dropped()
	{
		Owner = null;
		if (OwnerStats)
		{
			OwnerStats.StatusEffectEvent -= StatsChange;
			StatsCheck();
		}
		RBody.isKinematic = false;
		PhysicsBodys.SetActive(true);
		//TODO: Delay trigger reenabling
		Trigger.enabled = true;
	}

	public void StatsChange(StatusEffect effect)
	{
		if(effect.isEffector && effect.EffectedStat.GetType() == typeof(ROFStat))
		{
			StatsCheck();
		}
	}

	public void StatsCheck()
	{
		if(OwnerStats)
		{
			ROF = (OwnerStats.GetStat<ROFStat>() + 1) * BaseROF;
		}
		else
		{
			ROF = BaseROF;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		WeaponSlot weaponSlot = other.GetComponent<WeaponSlot>();
		if(weaponSlot)
		{
			weaponSlot.SlotWeapon(this);
		}
	}
}
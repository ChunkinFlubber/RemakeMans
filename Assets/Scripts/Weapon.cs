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

	[Header("Weapon Stats")]
	[SerializeField]
	private float _ROF = 1.35f;
	public float ROF { get => _ROF; set { _ROF = value; RoundsDelta = 1 / _ROF; } }
	[SerializeField]
    float ProjectileSpeed = 30.0f;
	[SerializeField]
	public DamageType[] DamageTypes = null;


	public delegate void FireEvent(Projectile projectile);
	public FireEvent Fired = delegate { };

	public GameObject Owner { get; private set; }
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
		projectile.transform.parent = null;
		projectile.transform.position = MuzzleTransform.position;
		projectile.transform.rotation = MuzzleTransform.rotation;
		projectile.Setup(this, MuzzleTransform.forward, ProjectileSpeed);
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
		PhysicsBodys.SetActive(false);
		RBody.isKinematic = true;
		Trigger.enabled = false;
	}

	public void Dropped()
	{
		Owner = null;
		RBody.isKinematic = false;
		PhysicsBodys.SetActive(true);
		//TODO: Delay trigger reenabling
		Trigger.enabled = true;
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
using UnityEngine;
using UnityEngine.Experimental.Input;

public class Weapon : MonoBehaviour
{
    MasterInputs Input;
	[SerializeField]
	ProjectilePool ProPool = null;

	[SerializeField]
	private float _ROF = 1.35f;
	public float ROF { get => _ROF; set { _ROF = value; roundsDelta = 1 / _ROF; } }
	[SerializeField]
    float ProjectileSpeed = 10.0f;
    [SerializeField]
    Transform MuzzleTransform = null;

	public delegate void FireEvent(Projectile projectile);

	public FireEvent Fired = delegate { };

	bool isFiring = false;
	float roundsDelta = 0;
	float currDelta = 0;

	private void Start()
	{
		roundsDelta = 1 / ROF;
		currDelta = roundsDelta + 1f;
		if(ProPool == null)
		{
			ProPool = GetComponent<ProjectilePool>();
		}
	}

	//Handles Input
	public void Init(MasterInputs input)
    {
        Input = input;
        Input.Character.Fire.Enable();
        Input.Character.Fire.performed += Fire;
        Input.Character.Fire.cancelled += Fire;
	}

    public void Fire(InputAction.CallbackContext context)
	{
		isFiring = !isFiring;
	}

	private void Update()
	{
		currDelta += Time.deltaTime;
		if(isFiring)
		{
			if(currDelta >= roundsDelta)
			{
				Projectile projectile = SpawnProjectile();
				currDelta = 0;
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
		return projectile;
	}
}
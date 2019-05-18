using UnityEngine;

public class Projectile : MonoBehaviour
{
	ProjectilePool Master = null;
	DamageType TypeOfDamage = null;

	[SerializeField]
    float LifeTime = 10.0f;
    float CurrLifeTime;
	[SerializeField]
	int Damage = 10;
	[SerializeField]
	float CritMultiplier = 2.0f;
	float CritPercent = 0.0f;

	float Speed;
    Vector3 Direction;
    Collider Body;
    TrailRenderer Trail;
	GameObject Shooter = null;

	public void Init(ProjectilePool master)
	{
		Master = master;
	}

	void Awake()
    {
        Body = GetComponent<Collider>();
		Body.enabled = false;
        Trail = GetComponentInChildren<TrailRenderer>();
		TypeOfDamage = GetComponent<DamageType>();
    }

    void Update()
    {
        transform.Translate(Direction * Speed * Time.deltaTime, Space.World);
        CurrLifeTime += Time.deltaTime;
        if(CurrLifeTime > LifeTime)
        {
			ReturnMe();
        }
    }

    public void Setup(GameObject shooter, Vector3 direction, float speed = 10.0f, float critPercent = 0.0f)
    {
		Shooter = shooter;
        Direction = direction;
        Speed = speed;
		CritPercent = critPercent;
        CurrLifeTime = 0;
        Trail.Clear();
		Body.enabled = true;
    }

	private void ReturnMe()
	{
		Master.Return(this);
		gameObject.SetActive(false);
	}

	private void OnTriggerEnter(Collider collider)
	{
		HealthSystem HS = collider.gameObject.GetComponent<HealthSystem>();
		if(collider.gameObject != Shooter)
		{
			if(HS)
			{
				bool crit = Random.Range(0.01f,1) <= CritPercent;
				HS.ModifyHealth(Damage, TypeOfDamage, transform.position, crit);
			}
			Debug.Log(collider.gameObject);
			ReturnMe();
		}
	}
}

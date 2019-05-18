using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    int MaxHealth = 100;
    int CurrentHealth = 0;

	[SerializeField]
	bool isDamagable = true;
	[SerializeField]
	bool canDie = true;

	public delegate void HealthEvent(float change);
    public HealthEvent OnHealthChange = delegate{};
    public HealthEvent OnDamage = delegate{};
    public HealthEvent OnHeal = delegate{};
    public HealthEvent OnHealthChangePct = delegate{};
    public HealthEvent OnDeath = delegate{};

	void OnEnable()
    {
        CurrentHealth = MaxHealth;
    }

    public void ModifyHealth(int amount)
    {
		if (!isDamagable) return;
		CurrentHealth += amount;
		if (amount < 0)
		{
			OnDamage(amount);
		}
		else
		{
			OnHeal(amount);
		}
		OnHealthChange(amount);
		OnHealthChangePct((float)CurrentHealth / MaxHealth);
		if(CurrentHealth <= 0 && canDie)
		{
			CurrentHealth = 0;
			OnDeath(CurrentHealth);
		}
    }

	public void ModifyHealth(int amount, DamageType type, Vector3 position, bool crit)
	{
		ModifyHealth(amount);

		DamagePopUp dp = DamagePopUpPool.Instance.Get();
		dp.transform.position = position;
		dp.SetDamage(crit, amount, type?.DamageColor);
	}
}

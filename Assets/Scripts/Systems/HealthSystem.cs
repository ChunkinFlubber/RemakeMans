using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    float MaxHealth = 100;
    float CurrentHealth = 0;

	[SerializeField]
	bool isDamagable = true;
	[SerializeField]
	bool canDie = true;

	PopUpUIManager PopUpManager = null;

	public delegate void HealthEvent(float change);
    public HealthEvent OnHealthChange = delegate{};
    public HealthEvent OnDamage = delegate{};
    public HealthEvent OnHeal = delegate{};
    public HealthEvent OnHealthChangePct = delegate{};
    public HealthEvent OnDeath = delegate{};

	private void Start()
	{
		PopUpManager = PopUpUIManager.Instance;
	}

	void OnEnable()
    {
        CurrentHealth = MaxHealth;
    }

    public void ModifyHealth(float amount)
    {
		if (!isDamagable) return;
		CurrentHealth += amount;
		CurrentHealth = Mathf.Clamp(CurrentHealth, 0.0f, MaxHealth);
		if (amount < 0.0f)
		{
			OnDamage(amount);
		}
		else
		{
			OnHeal(amount);
		}
		OnHealthChange(amount);
		OnHealthChangePct(CurrentHealth / MaxHealth);
		if(CurrentHealth <= 0.0f && canDie)
		{
			CurrentHealth = 0.0f;
			OnDeath(CurrentHealth);
		}
    }

	public void ModifyHealth(float amount, DamageType[] types, Vector3 position, bool crit)
	{
		foreach (DamageType type in types)
		{
			//TODO: Make DamageType.Apply(HealthSystem) do all of the logic for damage Implement Resistance
			//amount = amount;

			ModifyHealth(amount);
			SpawnPopUp(crit, amount, type.Effect, position);
		}
	}

	public void ModifyHealth(float amount, DamageEffect damageEffect)
	{
		//TODO: Make DamageType.Apply(HealthSystem) do all of the logic for damage Implement Resistance
		//amount = amount;

		ModifyHealth(amount);
		SpawnPopUp(false, amount, damageEffect, transform.position);
	}

	private void SpawnPopUp(bool crit, float amount, DamageEffect damageEffect, Vector3 position)
	{
		if (PopUpManager)
		{
			DamagePopUp dp = PopUpManager.GetDamagePopUp();
			dp.transform.position = position;
			dp.SetDamage(crit, amount, damageEffect.DamageColor);
		}
	}
}
using System.Collections.Generic;
using UnityEngine;

struct ResistanceValue
{
	public DamageType Type;
	public float RValue;

	public ResistanceValue(DamageType type, float rValue)
	{
		Type = type;
		RValue = rValue;
	}
}

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    int MaxHealth = 100;
    int CurrentHealth = 0;

	[SerializeField]
	bool isDamagable = true;
	[SerializeField]
	bool canDie = true;

	[SerializeField]
	ResistanceValue[] StartingResistanceValues = null;

	Dictionary<DamageType,float> Resistances = null;

	public delegate void HealthEvent(float change);
    public HealthEvent OnHealthChange = delegate{};
    public HealthEvent OnDamage = delegate{};
    public HealthEvent OnHeal = delegate{};
    public HealthEvent OnHealthChangePct = delegate{};
    public HealthEvent OnDeath = delegate{};

	private void Awake()
	{
		Resistances = new Dictionary<DamageType, float>(StartingResistanceValues.Length);
		foreach (ResistanceValue resistanceValues in StartingResistanceValues)
		{
			Resistances.Add(resistanceValues.Type, resistanceValues.RValue);
		}
	}

	void OnEnable()
    {
        CurrentHealth = MaxHealth;
    }

    public void ModifyHealth(int amount)
    {
		if (!isDamagable) return;
		CurrentHealth += amount;
		CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
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
		amount = (int)Mathf.Ceil((1.0f - Resistances[type]) * amount);

		ModifyHealth(amount);

		DamagePopUp dp = PopUpUIManager.Instance.GetDamagePopUp();
		dp.transform.position = position;
		dp.SetDamage(crit, amount, type?.DamageColor);
	}
}

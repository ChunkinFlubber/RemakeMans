using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ResistanceValue
{
	[SerializeField]
	public DamageType Type;
	[SerializeField]
	public float ResistValue;
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
	PopUpUIManager PopUpManager = null;

	public delegate void HealthEvent(float change);
    public HealthEvent OnHealthChange = delegate{};
    public HealthEvent OnDamage = delegate{};
    public HealthEvent OnHeal = delegate{};
    public HealthEvent OnHealthChangePct = delegate{};
    public HealthEvent OnDeath = delegate{};

	private void Start()
	{
		if (StartingResistanceValues == null)
		{
			Resistances = new Dictionary<DamageType, float>();
			return;
		}
		Resistances = new Dictionary<DamageType, float>(StartingResistanceValues.Length);
		foreach (ResistanceValue resistanceValues in StartingResistanceValues)
		{
			Resistances.Add(resistanceValues.Type, resistanceValues.ResistValue);
		}
		PopUpManager = PopUpUIManager.Instance;
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

	public void ModifyHealth(int amount, DamageType[] types, Vector3 position, bool crit)
	{
		foreach (DamageType type in types)
		{
			//TODO: change how amount is used
			if (Resistances.ContainsKey(type))
			{
				amount = (int)Mathf.Ceil((1.0f - Resistances[type]) * amount);
			}

			ModifyHealth(amount);

			if(PopUpManager)
			{
				DamagePopUp dp = PopUpManager.GetDamagePopUp();
				dp.transform.position = position;
				dp.SetDamage(crit, amount, type?.DamageColor);
			}
		}
	}
}
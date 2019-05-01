using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    float MaxHealth = 100;
    float CurrentHealth = 0;

    public delegate void HealthChange(float change);
    public HealthChange OnHealthChange = delegate{};
    public HealthChange OnDamage = delegate{};
    public HealthChange OnHeal = delegate{};
    public HealthChange OnHealthChangePct = delegate{};

    void OnEnable()
    {
        CurrentHealth = MaxHealth;
    }

    public void ModifyHealth(int amount)
    {
        CurrentHealth += amount;
        if(amount < 0)
        {
            OnDamage((float)amount);
        }
        else
        {
            OnHeal((float)amount);
        }
        OnHealthChange((float)amount);
        OnHealthChangePct((float)CurrentHealth / (float)MaxHealth);
    }
}

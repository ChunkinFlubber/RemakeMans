using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Damage Effect", menuName = "Damage Effect")]
public class DamageEffect : StatusEffect
{
	[SerializeField]
	public Color DamageColor = Color.white;
	[SerializeField]
	protected float _Damage = 0.0f;
	public float Damage { get => _Damage; protected set { _Damage = value; } }
	[SerializeField]
	protected float _DurationOfDOT = 3.0f;
	public float DurrationOfDOT { get => _DurationOfDOT; protected set { _DurationOfDOT = value; } }
	[SerializeField]
	float DOTTiming = 0.333f;

	HealthSystem EffectedHealth = null;

	public virtual void SetDamage(float damage)
	{
		Damage = damage;
	}

	IEnumerator ApplyDOT()
	{
		float currentDuration = 0.0f;
		while(currentDuration < DurrationOfDOT)
		{
			currentDuration += DOTTiming;
			EffectedHealth.ModifyHealth(Damage, this);
			yield return new WaitForSeconds(DOTTiming);
		}
		Master.RemoveStatusEffect(this);
	}

	public override void Init(StatsSystem master)
	{
		base.Init(master);
		EffectedHealth = master.gameObject.GetComponent<HealthSystem>();
		if (EffectedHealth)
		{
			Master.StartCoroutine(ApplyDOT());
		}
	}

	public override void Effect(ref float value)
	{
		base.Effect(ref value);
	}

	public override void Tick()
	{
		base.Tick();
	}

	public override void AddStack()
	{
		base.AddStack();
		if(EffectedHealth)
		{
			Master.StartCoroutine(ApplyDOT());
		}
	}

	public override void RemoveStack()
	{
		base.RemoveStack();
	}

	public override void Destroy()
	{
		base.Destroy();
	}
}

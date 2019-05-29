using System;
using System.Collections.Generic;
using UnityEngine;

public class StatsSystem : MonoBehaviour
{
	Dictionary<Type, StatusEffect> Effects;
	Dictionary<Type, Stat> Stats;

	public delegate void StatsEvent(StatusEffect statusEffect);
	public StatsEvent StatusEffectEvent = delegate { };


	private void Start()
	{
		Effects = new Dictionary<Type, StatusEffect>();
		Stats = new Dictionary<Type, Stat>();
		Stat[] rs = Resources.LoadAll<Stat>("Stats");
		foreach (Stat stat in rs)
		{
			Stat newStat = Instantiate(stat);
			Stats.Add(stat.GetType(), newStat);
		}
	}

	private void Update()
	{
		foreach (KeyValuePair<Type, StatusEffect> effect in Effects)
		{
			if (effect.Value.TickEnabled)
			{
				effect.Value.Tick();
			}
		}
	}


	public void AddStatusEffect(StatusEffect effect)
	{
		AddEffect(effect);
		AddEffector(effect);
		StatusEffectEvent(effect);
	}

	private void AddEffect(StatusEffect effect)
	{
		if (Effects.ContainsKey(effect.GetType()))
		{
			Effects[effect.GetType()].AddStack();
		}
		else
		{
			Effects.Add(effect.GetType(), effect);
			effect.Init(this);
		}
	}

	private void AddEffector(StatusEffect effect)
	{
		if (effect.isEffector)
		{
			if (Stats.ContainsKey(effect.EffectedStat.GetType()))
			{
				effect.Effect(ref Stats[effect.EffectedStat.GetType()].Value);
			}
			else
			{
				Stats.Add(effect.EffectedStat.GetType(), effect.EffectedStat);
				effect.Effect(ref Stats[effect.EffectedStat.GetType()].Value);
			}
		}
	}

	public void RemoveStatusEffect(StatusEffect effect)
	{
		if (Effects.ContainsKey(effect.GetType()))
		{
			Effects[effect.GetType()].RemoveStack();
		}
		if(effect.EffectedStat && Stats.ContainsKey(effect.EffectedStat.GetType()))
		{
			effect.Effect(ref Stats[effect.EffectedStat.GetType()].Value);
		}
		StatusEffectEvent(effect);
	}


	public float GetStat<T>()
	{
		if(Stats.ContainsKey(typeof(T)))
			return Stats[typeof(T)].Value;
		return 0.0f;
	}


	void OnDestroy()
	{
		foreach (KeyValuePair<Type, StatusEffect> effect in Effects)
		{
			effect.Value.Destroy();
		}
		Effects.Clear();
		Stats.Clear();
	}
}
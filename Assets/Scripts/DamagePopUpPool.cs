using System.Collections.Generic;
using UnityEngine;

public class DamagePopUpPool : MonoBehaviour
{
	public static DamagePopUpPool Instance { get; private set; }

	[SerializeField]
	private DamagePopUp prefab;

	private Queue<DamagePopUp> dpopAvailable = new Queue<DamagePopUp>();

	private void Awake()
	{
		Instance = this;
	}

	public DamagePopUp Get()
	{
		if (dpopAvailable.Count == 0)
		{
			return AddObject();
		}

		return dpopAvailable.Dequeue();
	}

	private DamagePopUp AddObject()
	{
		DamagePopUp damagePop = Instantiate(prefab);
		damagePop.Init(this);
		return damagePop;
	}

	public void Return(DamagePopUp damagePop)
	{
		dpopAvailable.Enqueue(damagePop);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpUIManager : MonoBehaviour
{
    static public PopUpUIManager Instance { get; private set; }

	[SerializeField]
	DamagePopUpPool DamagePool = null;

	private void Start()
	{
		Instance = this;
		if(DamagePool == null)
		{
			DamagePool = GetComponent<DamagePopUpPool>();
		}
	}

	public DamagePopUp GetDamagePopUp()
	{
		DamagePopUp dp = DamagePool.Get();
		dp.DestroyTime += ReturnDamagePopUp;
		return dp;
	}

	public void ReturnDamagePopUp(DamagePopUp dp)
	{
		dp.DestroyTime -= ReturnDamagePopUp;
		DamagePool.ReturnObject(dp);
	}
}

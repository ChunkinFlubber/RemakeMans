using UnityEngine;

[ExecuteInEditMode]
public class DamageTypeMaster : MonoBehaviour
{
	public DamageTypeMaster Instance { get; private set; }
	
	public DamageType[] DamageTypes = null;
	private void Start()
	{
		Instance = this;
		DamageTypes = Resources.LoadAll<DamageType>("DamageTypes");
	}
}

using UnityEngine;

[ExecuteInEditMode]
public class DamageTypeMaster : MonoBehaviour
{
	public DamageTypeMaster Instance { get; private set; }
	
	public DamageEffect[] DamageTypes = null;
	private void Start()
	{
		Instance = this;
		DamageTypes = Resources.LoadAll<DamageEffect>("DamageTypes");
	}
}

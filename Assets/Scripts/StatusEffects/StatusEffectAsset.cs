using UnityEngine;

public class StatusEffectAsset : MonoBehaviour
{
    [SerializeField]
    StatusEffect MyStatusEffect = null;

    void Start()
    {
        
    }
    
    void FixedUpdate()
    {
        
    }

	private void OnTriggerEnter(Collider other)
	{
		StatsSystem stats = other.GetComponent<StatsSystem>();
		if(stats)
		{
			stats.AddStatusEffect(MyStatusEffect);
			Destroy(gameObject);
		}
	}
}

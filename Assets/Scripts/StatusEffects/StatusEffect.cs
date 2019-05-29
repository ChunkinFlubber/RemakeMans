using UnityEngine;

[CreateAssetMenu(menuName = "StatusEffect/BaseStatusEffect", fileName = "New Status Effect")]
public class StatusEffect : ScriptableObject
{
	protected StatsSystem Master = null;
	protected int Stack = 1;

	[SerializeField]
	public Stat EffectedStat = null;
	[SerializeField]
	protected bool _TickEnabled = true;
	public bool TickEnabled { get => _TickEnabled; protected set { _TickEnabled = value; } }
	[SerializeField]
	protected bool _isEffector = true;
	public bool isEffector { get => _isEffector; private set { _isEffector = value; } }

	virtual public void Init(StatsSystem master)
	{
		Master = master;
	}

	virtual public void Tick()
	{

	}

	virtual public void Effect(ref float value)
	{

	}

	virtual public void AddStack()
	{
		++Stack;
	}

	virtual public void RemoveStack()
	{
		--Stack;
		Stack = Mathf.Clamp(Stack, 0, 100);
	}

	virtual public void Destroy()
	{

	}
}
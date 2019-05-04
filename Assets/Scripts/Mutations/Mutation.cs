using UnityEngine;

[CreateAssetMenu(menuName = "Mutations/BaseMutation", fileName = "BaseMutation")]
public class Mutation : ScriptableObject
{
    [SerializeField]
    public bool TickEnabled = false;
    protected int Stack = 1;
    protected MutationSystem Master = null;

    virtual public void Init(MutationSystem master)
    {
        Master = master;
    }

    virtual public void Tick()
    {

    }

    virtual public void AddStack()
    {
        
    }

    virtual public void RemoveStack()
    {

    }

    virtual public void Destroy()
    {

    }
}

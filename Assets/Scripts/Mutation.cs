using UnityEngine;

public class Mutation
{
    public bool TickEnabled = false;
    public int Stack = 0;
    virtual public void Tick()
    {

    }

    virtual public void Init(MutationSystem master)
    {
        //Use master to setup mutation; such as connecting to MaxSpeed and changing it.
    }

    virtual public void Destroy()
    {

    }
}

using UnityEngine;

public class BillboardObject : MonoBehaviour
{
	Transform PlayerTransform = null;
	private void Start()
	{
		PlayerTransform = FindObjectOfType<Character>().transform;
	}
	void FixedUpdate()
    {
        if(PlayerTransform)
		{
			transform.LookAt(PlayerTransform);
		}
    }
}

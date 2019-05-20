using System.Collections.Generic;
using UnityEngine;

public class GenericPool<T> : MonoBehaviour where T : MonoBehaviour
{
	// Prefab for this pool. The prefab must have a component of type T on it.
	[SerializeField]
	T ObjectPrefab;

	// Size of this object pool
	[SerializeField]
	public int SizeofPool;

	// The list of free and used objects for tracking.
	// We use the generic collections so we can give them our type T.
	private List<T> FreeList;
	private List<T> UsedList;

	public void Awake()
	{
		FreeList = new List<T>(SizeofPool);
		UsedList = new List<T>(SizeofPool);

		// Instantiate the pooled objects and disable them.
		for (var i = 0; i < SizeofPool; i++)
		{
			var pooledObject = Instantiate(ObjectPrefab, transform);
			pooledObject.gameObject.SetActive(false);
			FreeList.Add(pooledObject);
		}
	}

	public T Get()
	{
		T pooledObject;
		int numFree = FreeList.Count;
		if (numFree == 0)
		{
			pooledObject = Instantiate(ObjectPrefab);
			pooledObject.gameObject.SetActive(false);
			UsedList.Add(pooledObject);
			++SizeofPool;
			return pooledObject;
		}

		// Pull an object from the end of the free list.
		pooledObject = FreeList[numFree - 1];
		FreeList.RemoveAt(numFree - 1);
		UsedList.Add(pooledObject);
		return pooledObject;
	}

	public void ReturnObject(T pooledObject)
	{
		Debug.Assert(UsedList.Contains(pooledObject));

		// Put the pooled object back in the free list.
		UsedList.Remove(pooledObject);
		FreeList.Add(pooledObject);

		// Reparent the pooled object to us, and disable it.
		Transform pooledObjectTransform = pooledObject.transform;
		pooledObjectTransform.parent = transform;
		pooledObjectTransform.localPosition = Vector3.zero;
		pooledObject.gameObject.SetActive(false);
	}
}

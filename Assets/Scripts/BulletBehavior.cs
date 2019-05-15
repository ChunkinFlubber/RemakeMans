using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(Mathf.Sin(Time.time * Random.Range(-10,10)), Mathf.Sin(Time.time * Random.Range(-10,10)), 0) * Time.deltaTime * Random.Range(-10,10);
    }
}

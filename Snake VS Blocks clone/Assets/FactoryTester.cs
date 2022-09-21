using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryTester : MonoBehaviour
{
    public ObjectsPool pool;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            GameObject go = pool.GetObject();
            go.transform.parent = gameObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

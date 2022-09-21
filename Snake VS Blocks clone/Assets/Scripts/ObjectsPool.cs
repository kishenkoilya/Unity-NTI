using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    [SerializeField] private List<GameObject> objects = new List<GameObject>();
    [SerializeField] private Factory objectFactory;
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            objects.Add(transform.GetChild(i).gameObject);
        }
    }

    public void ReturnObject(GameObject obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(gameObject.transform);
        obj.transform.position = Vector3.zero;
        objects.Add(obj);
    }

    public GameObject GetObject()
    {
        int lastIndex = objects.Count - 1;
        GameObject obj;
        if (lastIndex >= 0)
        {
            objects[lastIndex].gameObject.SetActive(true);
            obj = objects[lastIndex];
            objects.RemoveAt(lastIndex);
            return obj;
        }
        return objectFactory.InstantiateObject();
    }
}

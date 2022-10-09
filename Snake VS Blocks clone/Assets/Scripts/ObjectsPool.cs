using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    [SerializeField] private List<GameObject> objects = new List<GameObject>();
    [SerializeField] private Factory objectFactory;
    [SerializeField] private float deactivationTimeout = 2;
    private List<(int, float)> objectDeactivationTimeouts = new List<(int, float)>();
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
        // obj.gameObject.SetActive(false);
        obj.transform.SetParent(gameObject.transform);
        obj.transform.localPosition = Vector3.zero;
        objects.Add(obj);
        objectDeactivationTimeouts.Add((gameObject.transform.childCount - 1, deactivationTimeout));
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

    private void Update() {
        for (int i = 0; i < objectDeactivationTimeouts.Count; i++)
        {
            objectDeactivationTimeouts[i] = (objectDeactivationTimeouts[i].Item1, objectDeactivationTimeouts[i].Item2 - Time.deltaTime);
            if (objectDeactivationTimeouts[i].Item2 <= 0)
            {
                transform.GetChild(objectDeactivationTimeouts[i].Item1).gameObject.SetActive(false);
                objectDeactivationTimeouts.RemoveAt(i);
                i--;
            }  
        }
    }
}

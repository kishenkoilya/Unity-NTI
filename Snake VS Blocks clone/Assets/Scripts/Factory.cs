using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] protected GameObject objectPrefab;

    public virtual GameObject InstantiateObject(Transform parent = null)
    {
        if (parent)
            return GameObject.Instantiate(objectPrefab, parent);
        else
            return GameObject.Instantiate(objectPrefab);
    }
}

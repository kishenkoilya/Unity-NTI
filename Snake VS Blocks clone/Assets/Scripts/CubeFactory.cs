using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFactory : Factory
{
    [SerializeField] private Material material;
    public override GameObject InstantiateObject(Transform parent = null)
    {
        Material materialCopy = new Material(material);
        GameObject cube;
        if (parent)
            cube = GameObject.Instantiate(objectPrefab, parent);
        else
            cube = GameObject.Instantiate(objectPrefab);
        cube.GetComponent<Renderer>().material = materialCopy;
        return cube;
    }
}

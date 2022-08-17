using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Screen : MonoBehaviour
{
    [SerializeField] private GameObject[] screenObjects;

    public void ActivateScreen() 
    {
        SetObjectsStatus(true);
    }
    public void DeactivateScreen() 
    {
        SetObjectsStatus(false);
    }

    private void SetObjectsStatus(bool status) 
    {
        foreach (GameObject obj in screenObjects) 
        {
            obj.SetActive(status);
        }
    }
}

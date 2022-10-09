using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScreenScript : MonoBehaviour
{
    [SerializeField] private GameObject[] screenObjects;

    public void ActivateScreen()
    {
        SetScreenObjectsActivity(true);
    }

    public void DeactivateScreen()
    {
        SetScreenObjectsActivity(false);
    }

    private void SetScreenObjectsActivity(bool flag)
    {
        foreach (GameObject obj in screenObjects)
        {
            obj.SetActive(flag);
        }
    }
}


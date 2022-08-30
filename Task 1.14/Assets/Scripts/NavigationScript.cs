using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationScript : MonoBehaviour
{
    [SerializeField] private Transform Goal;
    private NavMeshAgent Navi;
    // Start is called before the first frame update
    void Start()
    {
        Navi = GetComponent<NavMeshAgent>();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        Navi.destination = Goal.position;
    }
}

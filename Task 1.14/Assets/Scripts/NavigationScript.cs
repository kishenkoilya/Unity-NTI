using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationScript : MonoBehaviour
{
    [SerializeField] private Transform Goal;
    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent Navi = GetComponent<NavMeshAgent>();
        Navi.destination = Goal.position;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : MonoBehaviour
{
    [SerializeField] private List<Transform> PatrollingRoute;
    private int CurrentRouteSpot = 0;
    private Vector3 CurrentDestination;
    private float WaitingForSeconds = 0;
    private bool Moving = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (!Moving) {
            WaitingForSeconds += Time.deltaTime;
            if (WaitingForSeconds >= 1) {
                CurrentRouteSpot = (CurrentRouteSpot + 1) % PatrollingRoute.Count;
                CurrentDestination = PatrollingRoute[CurrentRouteSpot].position;
                Moving = true;
                WaitingForSeconds = 0;
            }
        }
        else {
            transform.position += (CurrentDestination - transform.position) * Time.deltaTime * 3;
            if ((transform.position - CurrentDestination).magnitude < 0.1) {
                Moving = false;
            }
        }
    }

}

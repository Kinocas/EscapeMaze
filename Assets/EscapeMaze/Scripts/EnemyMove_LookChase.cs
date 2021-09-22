using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove_LookChase : MonoBehaviour
{
    private NavMeshAgent agent;
    private RaycastHit[] raycastHits = new RaycastHit[10];

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void OnDetectObject(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            Vector3 positionDiff = collider.transform.position - transform.position;
            float distance = positionDiff.magnitude;
            Vector3 direction = positionDiff.normalized;
            int hitCount = Physics.RaycastNonAlloc(transform.position, direction, raycastHits, distance);
            if (hitCount == 0)
            {
                agent.isStopped = false;
                agent.destination = collider.transform.position;
            }
            else
            {
                agent.isStopped = true;
            }  
        }
    }
}

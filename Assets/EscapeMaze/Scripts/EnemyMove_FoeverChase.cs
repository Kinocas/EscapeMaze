using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove_FoeverChase : MonoBehaviour
{
    private GameObject targetObject;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        targetObject = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = targetObject.transform.position;
    }
}

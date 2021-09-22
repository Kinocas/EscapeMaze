using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove_Standard : MonoBehaviour
{
    private NavMeshAgent agent;
    private RaycastHit[] raycastHits = new RaycastHit[10];

    public float wanderRange = 10.0f;

    //設定した待機時間
    [SerializeField] float waitTime = 2;
    //待機時間を数える
    [SerializeField] float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetDestination();
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
        }
    }
    void Update()
    {
        //経路探索の準備ができておらず
        //目標地点までの距離が0.5m未満ならNavMeshAgentを止める
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            StopHere();
        }
    }

    void SetDestination()
    {
        agent.isStopped = false;
        Vector3 randomPos = new Vector3(Random.Range(-wanderRange, wanderRange), 0, Random.Range(-wanderRange, wanderRange));
        agent.destination = randomPos;
    }

    void StopHere()
    {
        //NavMeshAgentを止める
        agent.isStopped = true;
        //待ち時間を数える
        time += Time.deltaTime;

        //待ち時間が設定された数値を超えると発動
        if (time > waitTime)
        {
            //目標地点を設定し直す
            SetDestination();
            time = 0;
        }
    }
}

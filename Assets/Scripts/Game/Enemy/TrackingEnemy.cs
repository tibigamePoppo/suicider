using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrackingEnemy : MonoBehaviour
{
    [Header("移動速度")]
    [SerializeField]
    private float speed = 1.0f;
    [Header("停止距離")]
    [SerializeField]
    private float stoppingDistance = 0;
    [SerializeField]
    NavMeshAgent2D agent; //NavMeshAgent2Dを使用するための変数
    private GameObject target; //追跡するターゲット
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        agent.speed = speed;
        agent.stoppingDistance = stoppingDistance;
    }

    void FixedUpdate()
    {
        if(target == null)
        {
            target = GameObject.FindWithTag("Player");
        }
        else
        {
            agent.destination = target.transform.position; //agentの目的地をtargetの座標にする
        }
    }
}

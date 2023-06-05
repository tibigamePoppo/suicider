using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrackingEnemy : MonoBehaviour
{
    [Header("�ړ����x")]
    [SerializeField]
    private float speed = 1.0f;
    [Header("��~����")]
    [SerializeField]
    private float stoppingDistance = 0;
    [SerializeField]
    NavMeshAgent2D agent; //NavMeshAgent2D���g�p���邽�߂̕ϐ�
    private GameObject target; //�ǐՂ���^�[�Q�b�g
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
            agent.destination = target.transform.position; //agent�̖ړI�n��target�̍��W�ɂ���
        }
    }
}

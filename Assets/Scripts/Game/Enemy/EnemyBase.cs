using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField]

    private float moveSpeed;//�L�����N�^�[�̈ړ����x
    private EnemyState state;
    private void ChangeState(EnemyState s)
    {
        state = s;
        switch (state)
        {
            case EnemyState.Idle:
                break;
            case EnemyState.Walk:
                break;
            case EnemyState.Attack:
                break;
            case EnemyState.Action1:
                break;
            default:
                break;
        }
    }

}

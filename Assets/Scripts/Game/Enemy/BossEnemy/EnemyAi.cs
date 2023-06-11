using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyAi : MonoBehaviour
    {
        [Header("参照元")]
        [SerializeField]
        private EnemyBase stater;

        [Header("数値")]
        [SerializeField]
        private float actiontimer;


        [Header("重み")]
        [SerializeField]
        private float idleWeight;
        [SerializeField]
        private float attackWeight;
        [SerializeField]
        private float moveWeight;
        private float baseIdleWeight = 1;
        private float baseAttackWeight = 1;
        private float baseMoveWeight = 1;

        private GameObject Player;
        void Start()
        {
            StartCoroutine(ActionTimer());
        }

        /// <summary>
        /// 次のアクションを起こすまでの時間
        /// </summary>
        IEnumerator ActionTimer()
        {
            while (true)
            {
                yield return new WaitForSeconds(actiontimer);
                var Action = ActionState();
                Debug.Log(Action);
                switch (Action)
                {
                    case EnemyState.Idle:
                        stater.ChangeState(EnemyState.Idle);
                        break;
                    case EnemyState.Walk:
                        stater.ChangeState(EnemyState.Walk);
                        break;
                    case EnemyState.Attack:
                        stater.ChangeState(EnemyState.Attack);
                        break;
                    case EnemyState.Action1:
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// プレイヤーの情報を取得
        /// </summary>
        private GameObject getPlayer()
        {
            return Player = GameObject.FindWithTag("Player");
        }

        /// <summary>
        /// 行うアクションの値を返す
        /// </summary>
        private EnemyState ActionState()
        {
            float fullValue = IdleValue() + AttackValue() + MoveValue();
            float RandomAvtionValue = UnityEngine.Random.Range(0, fullValue);
            Debug.Log(RandomAvtionValue);
            if (RandomAvtionValue < IdleValue())
            {
                return EnemyState.Idle;
            }
            else if(RandomAvtionValue < IdleValue() + AttackValue())
            {
                return EnemyState.Attack;
            }
            else
            {
                return EnemyState.Walk;
            }

        }

        /// <summary>
        /// 待機状態の可能性の基礎値と待機の可能性の重みを合わせた数値
        /// </summary>
        private float IdleValue()
        {
            return baseIdleWeight * idleWeight;
        }
        /// <summary>
        /// 攻撃状態の可能性の基礎値と攻撃の可能性の重みを合わせた数値
        /// </summary>
        private float AttackValue()
        {
            return baseAttackWeight * attackWeight;
        }
        /// <summary>
        /// 移動状態の可能性の基礎値と移動の可能性の重みを合わせた数値
        /// </summary>
        private float MoveValue()
        {
            return baseMoveWeight * moveWeight;
        }
    }
}
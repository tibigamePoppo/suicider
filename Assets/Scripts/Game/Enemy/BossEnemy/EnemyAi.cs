using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyAi : MonoBehaviour
    {
        [Header("�Q�ƌ�")]
        [SerializeField]
        private EnemyBase stater;

        [Header("���l")]
        [SerializeField]
        private float actiontimer;


        [Header("�d��")]
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
        /// ���̃A�N�V�������N�����܂ł̎���
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
        /// �v���C���[�̏����擾
        /// </summary>
        private GameObject getPlayer()
        {
            return Player = GameObject.FindWithTag("Player");
        }

        /// <summary>
        /// �s���A�N�V�����̒l��Ԃ�
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
        /// �ҋ@��Ԃ̉\���̊�b�l�Ƒҋ@�̉\���̏d�݂����킹�����l
        /// </summary>
        private float IdleValue()
        {
            return baseIdleWeight * idleWeight;
        }
        /// <summary>
        /// �U����Ԃ̉\���̊�b�l�ƍU���̉\���̏d�݂����킹�����l
        /// </summary>
        private float AttackValue()
        {
            return baseAttackWeight * attackWeight;
        }
        /// <summary>
        /// �ړ���Ԃ̉\���̊�b�l�ƈړ��̉\���̏d�݂����킹�����l
        /// </summary>
        private float MoveValue()
        {
            return baseMoveWeight * moveWeight;
        }
    }
}
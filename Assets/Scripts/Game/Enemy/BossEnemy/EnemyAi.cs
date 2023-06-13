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
        [SerializeField]
        private float spellWeight;
        private float baseIdleWeight = 1;
        private float baseAttackWeight = 1;
        private float baseMoveWeight = 1;
        private float baseSpellWeight = 1;
        private float IdleCountWeight = 1;
        private float moveDistanceWeight = 1;
        private float attackDistanceWeight = 1;
        private float attackPlayerPosWeight = 0.8f;
        private float spellDistanceWeight = 1;

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
                        stater.ChangeState(EnemyState.Action1);
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
            float fullValue = IdleValue() + AttackValue() + MoveValue() + SpellValue();
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
            else if (RandomAvtionValue < IdleValue() + AttackValue() + MoveValue())
            {
                return EnemyState.Walk;
            }
            else
            {
                return EnemyState.Action1;
            }

        }

        /// <summary>
        /// �ҋ@��Ԃ̉\���̊�b�l�Ƒҋ@�̉\���̏d�݂����킹�����l
        /// </summary>
        private float IdleValue()
        {
            IdleCountWeight *= 0.8f;
            return baseIdleWeight * idleWeight * IdleCountWeight;
        }
        /// <summary>
        /// �U����Ԃ̉\���̊�b�l�ƍU���̉\���̏d�݂����킹�����l
        /// </summary>
        private float AttackValue()
        {
            //�v���C���[�Ƃ̋������߂����ǂ���
            if (PlayerDistance() <= 2.2) attackDistanceWeight = 1.6f;
            else attackDistanceWeight = 1;

            //�v���C���[�����ɂ��邩�ǂ���
            if (Player.transform.position.x + 0.8f > transform.position.x) attackPlayerPosWeight = 1.2f;
            else attackPlayerPosWeight = 0.8f;

                return baseAttackWeight * attackWeight * attackDistanceWeight * attackPlayerPosWeight;
        }
        /// <summary>
        /// �ړ���Ԃ̉\���̊�b�l�ƈړ��̉\���̏d�݂����킹�����l
        /// </summary>
        private float MoveValue()
        {
            if (PlayerDistance() >= 4) moveDistanceWeight = 1.4f;
            else moveDistanceWeight = 1;
            return baseMoveWeight * moveWeight * moveDistanceWeight;
        }
        /// <summary>
        /// �ŗL�A�N�V������Ԃ̉\���̊�b�l�� �ŗL�A�N�V�����̉\���̏d�݂����킹�����l
        /// </summary>
        private float SpellValue()
        {
            if (PlayerDistance() >= 6) spellDistanceWeight = 2.4f;
            else if (PlayerDistance() >= 4) spellDistanceWeight = 1.8f;
            else spellDistanceWeight = 1;
            return baseSpellWeight * spellWeight * spellDistanceWeight;
        }
        
        private float PlayerDistance()
        {
            float value = 100;
            if (Player == null) getPlayer();
            if (Player != null)
            {
                value = Vector3.Distance(Player.transform.position, transform.position);
            }

            return value;
        }
    }
}
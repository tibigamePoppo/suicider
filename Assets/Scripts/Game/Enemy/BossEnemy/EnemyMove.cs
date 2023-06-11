using UnityEngine;

namespace Enemy
{
    public class EnemyMove : MonoBehaviour, StateActionInterface
    {
        GameObject Player = null;
        [Header("�Q�ƌ�")]
        [SerializeField]
        private AnimationController animationController;
        [Header("�X�e�[�^�X")]
        [SerializeField]
        private float moveSpeed;
        private bool isMove;
        public void StateAction()
        {
            isMove = true;
            animationController.Walk(true);
        }
        public void StateEndAction()
        {
            isMove = false;
            animationController.Walk(false);
        }

        void Start()
        {
            if (Player == null) Player = getPlayer();
        }

        void Update()
        {
            if (isMove)
            {
                if (Player == null) Player = getPlayer();
                Vector3 velocity = Vector3.zero;
                if (Player.transform.position.x > transform.position.x)
                {
                    velocity.x++;
                }
                else
                {
                    velocity.x--;
                }
                velocity = velocity * moveSpeed * Time.deltaTime;
                transform.position += new Vector3(velocity.x, velocity.y, 0);
            }
        }

        /// <summary>
        /// �v���C���[�̏����擾
        /// </summary>
        private GameObject getPlayer()
        {
            return Player = GameObject.FindWithTag("Player");
        }
    }
}
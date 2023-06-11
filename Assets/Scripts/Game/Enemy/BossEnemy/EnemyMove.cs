using UnityEngine;

namespace Enemy
{
    public class EnemyMove : MonoBehaviour, StateActionInterface
    {
        GameObject Player = null;
        [Header("参照元")]
        [SerializeField]
        private AnimationController animationController;
        [Header("ステータス")]
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
        /// プレイヤーの情報を取得
        /// </summary>
        private GameObject getPlayer()
        {
            return Player = GameObject.FindWithTag("Player");
        }
    }
}
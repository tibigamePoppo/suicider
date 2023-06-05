using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Controller : MonoBehaviour
    {
        [Header("移動速度")]
        [SerializeField]
        float speed;
        [Header("ジャンプ力")]
        [SerializeField]
        float jumpPower;
        [Header("設置判定のレイヤー")]
        [SerializeField]
        LayerMask layerMask;
        PlayerAnimator PlayerAnimatoin;
        Rigidbody2D rb2;
        Stage stage;

        void Start()
        {
            rb2 = GetComponent<Rigidbody2D>();
            PlayerAnimatoin = GetComponent<PlayerAnimator>();
            stage = FindObjectOfType<Stage>();
        }

        void FixedUpdate()
        {
            if (stage.state != Stage.stageState.playerAction) return;

                Vector2 moveVelocity = Vector2.zero;
            if (Input.GetKey(KeyCode.D)){
                moveVelocity.x++;
                turnScale(true);
            }
            if (Input.GetKey(KeyCode.A))
            {
                moveVelocity.x--;
                turnScale(false);
            }
            if(Input.GetKey(KeyCode.W)&& isGrounded())
            {
                PlayerAnimatoin.Jump();
                rb2.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
            }
            moveVelocity = moveVelocity * speed * Time.deltaTime;
            transform.position += new Vector3(moveVelocity.x, moveVelocity.y, 0);

            if(moveVelocity.sqrMagnitude != 0)
            {
                PlayerAnimatoin.Run(true);
            }
            else
            {
                PlayerAnimatoin.Run(false);
            }
            PlayerAnimatoin.Fall(rb2.velocity.y);
            PlayerAnimatoin.IsGround(isGrounded());
        }

        private bool isGrounded()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, layerMask);
            RaycastHit2D boxhit = Physics2D.BoxCast(transform.position, Vector3.one * 0.2f, 0, Vector2.down, 0.5f, layerMask);
            return boxhit.collider != null;
        }

        private void turnScale(bool isRight)
        {
            if (isRight)
                transform.localScale = new Vector3(1, 1, 1);
            else
                transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
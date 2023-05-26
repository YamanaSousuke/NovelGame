using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Novel
{
    // プレイヤーの制御
    public class Player : MonoBehaviour
    {
        // 移動スピード
        [SerializeField] private float speed = 0.0f;

        // 物理特性にる制御
        private new Rigidbody2D rigidbody = null;
        // アニメーションの制御
        private Animator animator = null;
        // 画像の表示を制御
        private SpriteRenderer sprite = null;
        // 移動
        private Vector2 move = new();
        // アクションがあるオブジェクトを取得する
        private IEvent action = null;
        // 会話やアイテムを拾ったときなどのアクション中かどうか
        private bool isAction = false;

        // アニメーションID
        private static readonly int horizontalId = Animator.StringToHash("Horizontal");
        private static readonly int verticalId = Animator.StringToHash("Vertical");
        private static readonly int isMoveId = Animator.StringToHash("IsMove");

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            sprite = GetComponent<SpriteRenderer>();
        }

        private void FixedUpdate()
        {
            // 移動
            rigidbody.velocity = move.normalized * speed;
        }

        // アクションが終了したとき
        private void OnActionEnd()
        {
            isAction = false;
        }

        // 移動の入力を受け取る
        public void OnMove(InputAction.CallbackContext context)
        {
            // アクション中なら行動を受け付けない
            if (isAction)
            {
                return;
            }

            move.x = context.ReadValue<Vector2>().x;
            move.y = context.ReadValue<Vector2>().y;

            // 右に移動したとき
            if (move.x > 0.0f)
            {
                sprite.flipX = false;
            }
            // 左に移動したら画像を反転させる
            else if (move.x < 0.0f)
            {
                sprite.flipX = true;
            }

            // 入力に応じてアニメーションを切り替える
            switch (context.phase)
            {
                case InputActionPhase.Started:
                animator.SetBool(isMoveId, true);
                break;

                case InputActionPhase.Performed:
                animator.SetFloat(horizontalId, move.x);
                animator.SetFloat(verticalId, move.y);
                break;

                case InputActionPhase.Canceled:
                animator.SetBool(isMoveId, false);
                break;
            }
        }

        // 会話、アイテムの取得の入力を受け取る
        public void OnAction(InputAction.CallbackContext context)
        {
            // 入力したとき
            if (context.phase == InputActionPhase.Started)
            {
                if (action != null)
                {
                    isAction = true;
                    action.Action(OnActionEnd);
                }
            }
        }

        // 接触開始
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IEvent action))
            {
                this.action = action;
            }
        }

        // 接触終了
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IEvent _))
            {
                action = null;
            }
        }
    }
}
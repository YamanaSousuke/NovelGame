using UnityEngine;
using UnityEngine.InputSystem;

namespace Novel
{
    // �v���C���[�̐���
    public class Player : MonoBehaviour
    {
        // �ړ��X�s�[�h
        [SerializeField] private float speed = 0.0f;

        // ���������ɂ鐧��
        private new Rigidbody2D rigidbody = null;
        // �A�j���[�V�����̐���
        private Animator animator = null;
        // �摜�̕\���𐧌䂷��
        private SpriteRenderer sprite = null;
        // �ړ�
        private Vector2 move = new();

        // �A�j���[�V����ID
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
            // �ړ�
            rigidbody.velocity = move.normalized * speed;
        }

        // �ړ��̓��͂��󂯎��
        public void OnMove(InputAction.CallbackContext context)
        {
            move.x = context.ReadValue<Vector2>().x;
            move.y = context.ReadValue<Vector2>().y;

            // �E�Ɉړ������Ƃ�
            if (move.x > 0.0f)
            {
                sprite.flipX = false;
            }
            // ���Ɉړ�������摜�𔽓]������
            else if (move.x < 0.0f)
            {
                sprite.flipX = true;
            }

            // ���͂ɉ����ăA�j���[�V������؂�ւ���
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
    }
}
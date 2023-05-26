using UnityEngine;
using UnityEngine.Events;
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
        // �摜�̕\���𐧌�
        private SpriteRenderer sprite = null;
        // �ړ�
        private Vector2 move = new();
        // �A�N�V����������I�u�W�F�N�g���擾����
        private IEvent action = null;
        // ��b��A�C�e�����E�����Ƃ��Ȃǂ̃A�N�V���������ǂ���
        private bool isAction = false;

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

        // �A�N�V�������I�������Ƃ�
        private void OnActionEnd()
        {
            isAction = false;
        }

        // �ړ��̓��͂��󂯎��
        public void OnMove(InputAction.CallbackContext context)
        {
            // �A�N�V�������Ȃ�s�����󂯕t���Ȃ�
            if (isAction)
            {
                return;
            }

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

        // ��b�A�A�C�e���̎擾�̓��͂��󂯎��
        public void OnAction(InputAction.CallbackContext context)
        {
            // ���͂����Ƃ�
            if (context.phase == InputActionPhase.Started)
            {
                if (action != null)
                {
                    isAction = true;
                    action.Action(OnActionEnd);
                }
            }
        }

        // �ڐG�J�n
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IEvent action))
            {
                this.action = action;
            }
        }

        // �ڐG�I��
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IEvent _))
            {
                action = null;
            }
        }
    }
}
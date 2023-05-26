using UnityEngine;
using UnityEngine.Events;

namespace Novel
{
    // �X�e�[�W�̐i�s�Ǘ����s��
    public class StageScene : MonoBehaviour
    {
        // ���̃N���X�̃C���X�^���X
        public static StageScene Instance { get; private set; } = null;

        // ��b���̐i�s���Ǘ�����
        [SerializeField] private DialogueManager dialogue = null;

        private void Awake()
        {
            Instance = this;
        }

        // ��b���̕\��
        public void ShowDialogue(DialogueTable table, UnityAction onActionEnd)
        {
            dialogue.ShowDialogueUI(table.Data, onActionEnd);
        }
    }
}

using UnityEngine;
using UnityEngine.Events;

namespace Novel
{
    // ��b���̐i�s���Ǘ�����
    public class DialogueManager : MonoBehaviour
    {
        // ��b��UI
        [SerializeField] private DialogueUI dialogueUI = null;

        // ��b�̏��
        private DialogueData[] data = null;
        // ��b�̏����Ǘ�����C���f�b�N�X
        private int index = 0;
        // ��b���I�������Ƃ��̃C�x���g
        private UnityAction onDialogueEnd = null;

        // ��b��UI�̕\��
        public void ShowDialogueUI(DialogueData[] data, UnityAction onActionEnd)
        {
            index = 0;
            onDialogueEnd += onActionEnd;
            this.data = data;

            dialogueUI.SetDataToText(this.data[index]);
            dialogueUI.ShowUI();
        }

        // �e�L�X�g�{�b�N�X���N���b�N�����Ƃ�
        public void OnClickTextBox()
        {
            // ���͂�\�����ł���Ύ󂯕t���Ȃ�x
            if (dialogueUI.IsTypeSentence)
            {
                return;
            }

            // �����̕��͂̕\��
            if (data.Length - 1 > index)
            {
                index++;
                dialogueUI.SetDataToText(data[index]);
            }
            // ��b��UI���\���ɂ���
            else
            {
                onDialogueEnd?.Invoke();
                dialogueUI.HideUI();
                onDialogueEnd = null;
            }
        }
    }
}
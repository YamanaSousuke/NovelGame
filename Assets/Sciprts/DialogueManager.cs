using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Novel
{
    // ��b���̐i�s���Ǘ�����
    public class DialogueManager : MonoBehaviour
    {
        // ��b��UI
        [SerializeField] private GameObject dialogueUI = null;
        // ���O�̃e�L�X�g
        [SerializeField] private TextMeshProUGUI nameText = null;
        // ���b�Z�[�W�̃e�L�X�g
        [SerializeField] private TextMeshProUGUI messageText = null;

        // ��b�̏��
        private DialogueData[] data = null;
        // ��b�̏����Ǘ�����C���f�b�N�X
        private int index = 0;
        // ���͂�\�������ǂ���
        private bool isTypeSentence = false;
        // ��b���I�������Ƃ��̃C�x���g
        private UnityAction onDialogueEnd = null;

        // ��b��UI�̕\��
        public void ShowDialogueUI(DialogueData[] data, UnityAction onActionEnd)
        {
            index = 0;
            onDialogueEnd += onActionEnd;
            this.data = data;
            nameText.text = this.data[index].Name;
            StartCoroutine(OnTypeSentence(this.data[index].Message));
            dialogueUI.SetActive(true);
        }

        // 1�����������̕\�����s��
        private IEnumerator OnTypeSentence(string message)
        {
            isTypeSentence = true;

            yield return new WaitForSeconds(0.2f);
            messageText.text  = "";
            foreach (var letter in message.ToCharArray())
            {
                messageText.text += letter;
                yield return new WaitForSeconds(0.01f);
            }

            isTypeSentence = false;
        }

        // �e�L�X�g�{�b�N�X���N���b�N�����Ƃ�
        public void OnClickTextBox()
        {
            // ���͂�\�����ł���Ύ󂯕t���Ȃ�x
            if (isTypeSentence)
            {
                return;
            }

            // �����̕��͂̕\��
            if (data.Length - 1 > index)
            {
                index++;
                var currentDialogue = data[index];
                nameText.text = currentDialogue.Name;
                StartCoroutine(OnTypeSentence(currentDialogue.Message));
            }
            // ��b��UI���\���ɂ���
            else
            {
                onDialogueEnd?.Invoke();
                dialogueUI.SetActive(false);
                onDialogueEnd = null;
            }
        }
    }
}
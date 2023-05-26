using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

namespace Novel
{
    // ��b��UI�̊Ǘ�
    public class DialogueUI : MonoBehaviour
    {
        // ���O�̃e�L�X�g
        [SerializeField] private TextMeshProUGUI nameText = null;
        // ���b�Z�[�W�̃e�L�X�g
        [SerializeField] private TextMeshProUGUI messageText = null;
        [Header("��b��\������܂ł̒x������")]
        [SerializeField] private float dialogueDelay = 0.0f;
        [Header("1�������\������Ƃ��̃C���^�[�o��")]
        [SerializeField] private float interval = 0.0f;

        // �w�i�摜
        private Image image = null;

        // ���͂�\�������ǂ���
        public bool IsTypeSentence { get; private set; } = false;

        private void Start()
        {
            image = GetComponent<Image>();
        }

        // �e�L�X�g�Ƀf�[�^��ݒ肷��
        public void SetDataToText(DialogueData data)
        {
            nameText.text = data.Name;
            StartCoroutine(OnTypeSentence(data.Message));
        }

        // 1�����������̕\�����s��
        private IEnumerator OnTypeSentence(string message)
        {
            IsTypeSentence = true;
            messageText.text = "";
            yield return new WaitForSeconds(dialogueDelay);
            
            foreach (var letter in message.ToCharArray())
            {
                messageText.text += letter;
                yield return new WaitForSeconds(interval);
            }

            IsTypeSentence = false;
        }

        // UI�̕\��
        public void ShowUI()
        {
            image.enabled = true;
            foreach (Transform child in gameObject.transform)
            {
                child.gameObject.SetActive(true);
            }
        }

        // UI�̔�\��
        public void HideUI()
        {
            image.enabled = false;
            foreach (Transform child in gameObject.transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}

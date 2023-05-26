using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

namespace Novel
{
    // 会話文UIの管理
    public class DialogueUI : MonoBehaviour
    {
        // 名前のテキスト
        [SerializeField] private TextMeshProUGUI nameText = null;
        // メッセージのテキスト
        [SerializeField] private TextMeshProUGUI messageText = null;
        [Header("会話を表示するまでの遅延時間")]
        [SerializeField] private float dialogueDelay = 0.0f;
        [Header("1文字ずつ表示するときのインターバル")]
        [SerializeField] private float interval = 0.0f;

        // 背景画像
        private Image image = null;

        // 文章を表示中かどうか
        public bool IsTypeSentence { get; private set; } = false;

        private void Start()
        {
            image = GetComponent<Image>();
        }

        // テキストにデータを設定する
        public void SetDataToText(DialogueData data)
        {
            nameText.text = data.Name;
            StartCoroutine(OnTypeSentence(data.Message));
        }

        // 1文字ずつ文字の表示を行う
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

        // UIの表示
        public void ShowUI()
        {
            image.enabled = true;
            foreach (Transform child in gameObject.transform)
            {
                child.gameObject.SetActive(true);
            }
        }

        // UIの非表示
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

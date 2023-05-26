using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Novel
{
    // 会話文の進行を管理する
    public class DialogueManager : MonoBehaviour
    {
        // 会話文UI
        [SerializeField] private GameObject dialogueUI = null;
        // 名前のテキスト
        [SerializeField] private TextMeshProUGUI nameText = null;
        // メッセージのテキスト
        [SerializeField] private TextMeshProUGUI messageText = null;

        // 会話の情報
        private DialogueData[] data = null;
        // 会話の情報を管理するインデックス
        private int index = 0;
        // 文章を表示中かどうか
        private bool isTypeSentence = false;
        // 会話が終了したときのイベント
        private UnityAction onDialogueEnd = null;

        // 会話文UIの表示
        public void ShowDialogueUI(DialogueData[] data, UnityAction onActionEnd)
        {
            index = 0;
            onDialogueEnd += onActionEnd;
            this.data = data;
            nameText.text = this.data[index].Name;
            StartCoroutine(OnTypeSentence(this.data[index].Message));
            dialogueUI.SetActive(true);
        }

        // 1文字ずつ文字の表示を行う
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

        // テキストボックスをクリックしたとき
        public void OnClickTextBox()
        {
            // 文章を表示中であれば受け付けないx
            if (isTypeSentence)
            {
                return;
            }

            // 続きの文章の表示
            if (data.Length - 1 > index)
            {
                index++;
                var currentDialogue = data[index];
                nameText.text = currentDialogue.Name;
                StartCoroutine(OnTypeSentence(currentDialogue.Message));
            }
            // 会話文UIを非表示にする
            else
            {
                onDialogueEnd?.Invoke();
                dialogueUI.SetActive(false);
                onDialogueEnd = null;
            }
        }
    }
}
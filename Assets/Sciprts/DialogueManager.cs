using UnityEngine;
using UnityEngine.Events;

namespace Novel
{
    // 会話文の進行を管理する
    public class DialogueManager : MonoBehaviour
    {
        // 会話文UI
        [SerializeField] private DialogueUI dialogueUI = null;

        // 会話の情報
        private DialogueData[] data = null;
        // 会話の情報を管理するインデックス
        private int index = 0;
        // 会話が終了したときのイベント
        private UnityAction onDialogueEnd = null;

        // 会話文UIの表示
        public void ShowDialogueUI(DialogueData[] data, UnityAction onActionEnd)
        {
            index = 0;
            onDialogueEnd += onActionEnd;
            this.data = data;

            dialogueUI.SetDataToText(this.data[index]);
            dialogueUI.ShowUI();
        }

        // テキストボックスをクリックしたとき
        public void OnClickTextBox()
        {
            // 文章を表示中であれば受け付けないx
            if (dialogueUI.IsTypeSentence)
            {
                return;
            }

            // 続きの文章の表示
            if (data.Length - 1 > index)
            {
                index++;
                dialogueUI.SetDataToText(data[index]);
            }
            // 会話文UIを非表示にする
            else
            {
                onDialogueEnd?.Invoke();
                dialogueUI.HideUI();
                onDialogueEnd = null;
            }
        }
    }
}
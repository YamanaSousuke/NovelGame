using UnityEngine;
using UnityEngine.Events;

namespace Novel
{
    // ステージの進行管理を行う
    public class StageScene : MonoBehaviour
    {
        // このクラスのインスタンス
        public static StageScene Instance { get; private set; } = null;

        // 会話文の進行を管理する
        [SerializeField] private DialogueManager dialogue = null;

        private void Awake()
        {
            Instance = this;
        }

        // 会話文の表示
        public void ShowDialogue(DialogueTable table, UnityAction onActionEnd)
        {
            dialogue.ShowDialogueUI(table.Data, onActionEnd);
        }
    }
}

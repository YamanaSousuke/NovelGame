using UnityEngine;

namespace Novel
{
    // 会話の情報をまとめて管理する
    [CreateAssetMenu(menuName = "ScriptableObject/Dialogue", fileName = "DialogueData")]
    public class DialogueTable : ScriptableObject
    {
        [SerializeField] private DialogueData[] data = { null};
        public DialogueData[] Data { get => data; }
    }

    // 1かたまりの会話のデータ
    [System.Serializable]
    public class DialogueData
    {
        // 名前
        [SerializeField] private string name = "";
        public string Name { get => name; }
        // メッセージ
        [SerializeField] private string[] message = new string[] { "" };
        // 改行をつけて返す
        public string Message { 
            get
            {
                var message = "";
                for (int i = 0; i < this.message.Length; i++)
                {
                    message += this.message[i] + '\n';
                }
                return message[..^1];
            }
        }
        // 表示する画像
        [SerializeField] private Sprite image = null;
        public Sprite Image { get => image; }
    }
}
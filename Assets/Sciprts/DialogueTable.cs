using UnityEngine;

namespace Novel
{
    // ��b�̏����܂Ƃ߂ĊǗ�����
    [CreateAssetMenu(menuName = "ScriptableObject/Dialogue", fileName = "DialogueData")]
    public class DialogueTable : ScriptableObject
    {
        [SerializeField] private DialogueData[] data = { null};
        public DialogueData[] Data { get => data; }
    }

    // 1�����܂�̉�b�̃f�[�^
    [System.Serializable]
    public class DialogueData
    {
        // ���O
        [SerializeField] private string name = "";
        public string Name { get => name; }
        // ���b�Z�[�W
        [SerializeField] private string[] message = new string[] { "" };
        // ���s�����ĕԂ�
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
        // �\������摜
        [SerializeField] private Sprite image = null;
        public Sprite Image { get => image; }
    }
}
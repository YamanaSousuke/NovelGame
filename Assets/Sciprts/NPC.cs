using UnityEngine;
using UnityEngine.Events;

namespace Novel
{
    // フィールドのNPCの制御
    public class NPC : MonoBehaviour, IEvent
    {
        // プレイヤーから話しかけられたときに表示する会話データ
        [SerializeField] private DialogueTable data = null;

        // プレイヤーと接触中にアクションをしたとき
        public void Action(UnityAction onActionEnd)
        {
            StageScene.Instance.ShowDialogue(data, onActionEnd);
        }
    }
}

using System.Collections;
using UnityEngine.Events;

namespace Novel
{
    // プレイヤーと接触判定からイベントを発生させるインターフェース
    public interface IEvent
    {
        // プレイヤーと接触中にアクションをしたとき
        public void Action(UnityAction onActionEnd);
    }
}
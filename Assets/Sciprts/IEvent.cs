using System.Collections;
namespace Novel
{
    // プレイヤーと接触判定からイベントを発生させるインターフェース
    public interface IEvent
    {
        // プレイヤーと接触中にアクションをしたとき
        public void Action();
    }
}
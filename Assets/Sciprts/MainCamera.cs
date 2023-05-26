using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Novel
{
    // メインカメラを制御する
    public class MainCamera : MonoBehaviour
    {
        // プレイヤーのトランスフォーム
        [SerializeField] private Transform player = null;

        private void Update()
        {
            // プレイヤーに追従するようにする
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        }
    }
}

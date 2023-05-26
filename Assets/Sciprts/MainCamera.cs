using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Novel
{
    // ���C���J�����𐧌䂷��
    public class MainCamera : MonoBehaviour
    {
        // �v���C���[�̃g�����X�t�H�[��
        [SerializeField] private Transform player = null;

        private void Update()
        {
            // �v���C���[�ɒǏ]����悤�ɂ���
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        }
    }
}

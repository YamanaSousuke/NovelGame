using UnityEngine;
using UnityEngine.Events;

namespace Novel
{
    // �t�B�[���h��NPC�̐���
    public class NPC : MonoBehaviour, IEvent
    {
        // �v���C���[����b��������ꂽ�Ƃ��ɕ\�������b�f�[�^
        [SerializeField] private DialogueTable data = null;

        // �v���C���[�ƐڐG���ɃA�N�V�����������Ƃ�
        public void Action(UnityAction onActionEnd)
        {
            StageScene.Instance.ShowDialogue(data, onActionEnd);
        }
    }
}

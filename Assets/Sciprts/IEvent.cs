using System.Collections;
using UnityEngine.Events;

namespace Novel
{
    // �v���C���[�ƐڐG���肩��C�x���g�𔭐�������C���^�[�t�F�[�X
    public interface IEvent
    {
        // �v���C���[�ƐڐG���ɃA�N�V�����������Ƃ�
        public void Action(UnityAction onActionEnd);
    }
}
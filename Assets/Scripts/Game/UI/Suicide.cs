using UnityEngine;

public class Suicide : MonoBehaviour
{
    [SerializeField]
    Stage stage;
    /// <summary>
    /// �v���C���[���X�[�T�C�h�{�^�����������ꍇ�̏���
    /// </summary>
    public void PlayerSuicide()
    {
        if (stage.state == Stage.stageState.playerAction)
        {
            GameObject Player = GameObject.FindWithTag("Player");
            if(Player != null) Player.GetComponent<IDamageble>().AddDamage(1);
        }
    }
}

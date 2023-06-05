using UnityEngine;

public class Suicide : MonoBehaviour
{
    [SerializeField]
    Stage stage;
    /// <summary>
    /// プレイヤーがスーサイドボタンを押した場合の処理
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

using UnityEngine;

namespace GameStage
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StageData")]
    public class StageData : ScriptableObject
    {
        [Header("ステージ命名")]
        public string stageName;
        [Header("ステージ番号")]
        public int sutageNum;
        [Header("ステージオブジェクト")]
        public GameObject stage;
        [Header("目標ターン")]
        public int targetTurn;
    }
}
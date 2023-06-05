using UnityEngine;

namespace GameStage
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StageData")]
    public class StageData : ScriptableObject
    {
        [Header("�X�e�[�W����")]
        public string stageName;
        [Header("�X�e�[�W�ԍ�")]
        public int sutageNum;
        [Header("�X�e�[�W�I�u�W�F�N�g")]
        public GameObject stage;
        [Header("�ڕW�^�[��")]
        public int targetTurn;
    }
}
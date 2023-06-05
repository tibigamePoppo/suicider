using System.Collections.Generic;
using UnityEngine;

namespace GameStage
{
    [CreateAssetMenu(fileName = "StageDataLists", menuName = "ScriptableObjects/StageDataList")]
    public class StageDataList : ScriptableObject
    {
        public List<StageData> stageDataList;
    }
}
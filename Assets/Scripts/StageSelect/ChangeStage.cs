using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem;
using UnityEngine.SceneManagement;
namespace StageSelect
{
    public class ChangeStage : MonoBehaviour
    {
        [SerializeField]
        SceneObject scene;
        [SerializeField]
        StageType stage;
        public void StageScene()
        {
            switch (stage)
            {
                case StageType.cave:
                    GameManager.stageNum = 0;
                    break;
                case StageType.forest:
                    GameManager.stageNum = 6;
                    break;
                default:
                    break;
            }
            SceneManager.LoadScene(scene);
        }
    }
}
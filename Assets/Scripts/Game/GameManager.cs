using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GameStage;

namespace GameSystem
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        Stage stage;
        private int turn;
        public Action<int> turnChange;
        public Action<bool,int,bool> stageclear;
        [Header("�X�e�[�W�J���p�Ƀe�X�g���s�������Ƃ�")]
        [SerializeField]
        private bool developTest;
        [Header("�e�X�g���s���X�e�[�WID")]
        [SerializeField]
        private int developStageNum;
        public static int stageNum = 0;
        private string stageName;
        private int targetTurn;
        private GameObject StageObject;
        private int maxStage;


        private enum gameMode
        {
            /// <summary>
            /// �X�e�[�W�̏�����
            /// </summary>
            Ready,
            /// <summary>
            /// �v���C���[������\
            /// </summary>
            Play,
            /// <summary>
            /// ���U���g�̕\��
            /// </summary>
            Over,
        }
        private gameMode mode = gameMode.Ready;


        void Start()
        {
            if(developTest)
            {
                stageNum = developStageNum;
            }
            mode = gameMode.Play;
            maxStage = Resources.Load<StageDataList>("StageDataLists").stageDataList.Count;
            GetStageData(stageNum);
            stage.finish = Finish;
            stage.goal = Goal;
            stage.StageData = StageObject;
            stage.ChangeState(Stage.stageState.stageSet);
        }

        private void Finish(bool useTurn)
        {
            if (useTurn)
            {
                turn++;
                turnChange?.Invoke(turn);
            }
        }
        private void Goal(bool isEndStage)
        {
            if(mode == gameMode.Play)
            {
                Debug.Log($"GameManager.lastStage{isEndStage}");
                mode = gameMode.Over;
                stageclear?.Invoke(true, turn, isEndStage);
                stage.ChangeState(Stage.stageState.ruslt);
                turn = 0;
            }
        }

        public void NextStage()
        {
            if (stage.state != Stage.stageState.ruslt || mode != gameMode.Over) return;
            stageNum++;
            if (maxStage > stageNum)
            {
                Debug.Log($"maxStage = {maxStage},stageNum = {stageNum}");
                GetStageData(stageNum);
                stageclear?.Invoke(false, 0,false);
                turnChange?.Invoke(turn);
                stage.StageData = StageObject;
                stage.ChangeState(Stage.stageState.stageClear);
                mode = gameMode.Play;
            }
            else
            {
                Debug.LogWarning("���̃X�e�[�W�f�[�^�����݂��܂���");
            }
        }

        private void GetStageData(int stageNum)
        {
            var stageData = Resources.Load<StageDataList>("StageDataLists").stageDataList[stageNum];
            stageName = stageData.stageName;
            targetTurn = stageData.targetTurn;
            StageObject = stageData.stage;
            if(stageNum != stageData.sutageNum)
            {
                Debug.LogWarning ("�������X�e�[�W�f�[�^���ǂݍ��߂Ă��܂���");
            }
        }
        public void StageReset()
        {
            if (stage.state != Stage.stageState.playerAction || mode != gameMode.Play)
            {
                Debug.LogWarning($"�X�e�[�W�����Z�b�g���s���܂���ł���{stage.state}:{mode}");
                return;
            }
            turn = 0;
            turnChange?.Invoke(0);
            stage.ChangeState(Stage.stageState.stageClear);
            Debug.Log("���Z�b�g���s���܂���");
        }
    }
}
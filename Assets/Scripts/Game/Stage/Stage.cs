using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameStage;
using System.Threading.Tasks;

public class Stage : MonoBehaviour
{
    [Header("プレイヤーのゲームオブジェクト")]
    [SerializeField]
    GameObject playerPrefab;
    [Header("プレイヤーの死体オブジェクト")]
    [SerializeField]
    GameObject playerDeadPrefab;
    List<GameObject> deadObjects = new List<GameObject>();//プレイヤーの死体たち
    GameObject playerObject;
    public Vector2 spawnPoint;
    public Action<bool> finish;
    public Action<bool> goal;
    public GameObject StageData;
    private GameObject StageObject;

    public enum stageState
    {
        /// <summary>
        /// 必要なオブジェクトの配置
        /// </summary>
        stageSet,
        /// <summary>
        /// プレイヤーの操作
        /// </summary>
        playerAction,
        /// <summary>
        /// 死体のブロックのセット
        /// </summary>
        createDeadBlock,
        /// <summary>
        /// ステージのギミック再配置
        /// </summary>
        stageGimmickReset,
        /// <summary>
        /// リザルト画面
        /// </summary>
        ruslt,
        /// <summary>
        /// ステージの削除
        /// </summary>
        stageClear,
    }
    public stageState state { private set; get; }
    public async void ChangeState(stageState newState)
    {
        state = newState;
        switch (newState)
        {
            case stageState.stageSet:
                StageObject = Instantiate(StageData, transform.position, Quaternion.identity);
                StageObject.transform.parent = transform;
                await Task.Delay(10);
                playerObject = Instantiate(playerPrefab, spawnPoint, Quaternion.identity);
                PlayerInit(playerObject);
                ChangeState(stageState.playerAction);
                break;
            case stageState.playerAction:
                break;
            case stageState.createDeadBlock:
                Vector2 deadSpawnPoint = playerObject.transform.position;
                await Task.Delay(1000);

                var deadObj = Instantiate(playerDeadPrefab, deadSpawnPoint, Quaternion.identity);
                deadObjects.Add(deadObj);
                ChangeState(stageState.stageGimmickReset);
                break;
            case stageState.stageGimmickReset:
                if (StageObject != null) Destroy(StageObject);
                StageObject = Instantiate(StageData, transform.position, Quaternion.identity);
                StageObject.transform.parent = transform;
                playerObject = Instantiate(playerPrefab, spawnPoint, Quaternion.identity);
                PlayerInit(playerObject);
                await Task.Delay(100);
                ChangeState(stageState.playerAction);
                break;
            case stageState.ruslt:
                break;
            case stageState.stageClear:
                foreach (var item in deadObjects)
                {
                    Destroy(item);
                }
                deadObjects.Clear();
                if (playerObject != null) Destroy(playerObject);
                if (StageObject != null) Destroy(StageObject);
                ChangeState(stageState.stageSet);
                break;
        }
    }
    public void StageGoal(bool lastStage)
    {
        if (state == stageState.playerAction)
        {
            goal?.Invoke(lastStage);
            ChangeState(stageState.ruslt);
        }
    }

    private void PlayerInit(GameObject Player)
    {
        if(Player != null)
        {
           var deadEvent = Player.GetComponent<PlayerStatus>();           
           deadEvent.PlayerDead = PlayerDead;
        }
        else
        {
            Debug.LogError("Playerが存在しません");
        }
    }

    private void PlayerDead(bool isDead)
    {
        if (state == stageState.playerAction)
        {
            finish?.Invoke(true);
            if (isDead) ChangeState(stageState.createDeadBlock);
        }
    }
}

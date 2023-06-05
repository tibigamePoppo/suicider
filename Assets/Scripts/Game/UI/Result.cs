using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GameSystem;

public class Result : MonoBehaviour
{
    [Header("リザルト画面")]
    [SerializeField]
    GameObject result;
    [Header("GameManager")]
    [SerializeField]
    GameManager manager;
    [Header("ターン数を表示するtext")]
    [SerializeField]
    TextMeshProUGUI turnCountText;
    [Header("次のステージへ")]
    [SerializeField]
    GameObject nextStage;
    [Header("ステージセレクト画面へ")]
    [SerializeField]
    GameObject stageSelect;
    void Start()
    {
        manager.stageclear = openResult;
    }

    private void openResult(bool value,int turn,bool isEndStage)
    {
        if(value)
        {
            Debug.Log($"isEndStage{isEndStage}");
            if(isEndStage)
            {
                stageSelect.SetActive(true);
                nextStage.SetActive(false);
            }
            else
            {
                stageSelect.SetActive(false);
                nextStage.SetActive(true);
            }
            result.SetActive(true);
            turnCountText.text = $"ゴールまで積み上げた死体の数は{turn}体";
        }
        else
        {
            result.SetActive(false);
        }
    }
}

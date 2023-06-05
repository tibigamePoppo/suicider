using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GameSystem;

public class Result : MonoBehaviour
{
    [Header("���U���g���")]
    [SerializeField]
    GameObject result;
    [Header("GameManager")]
    [SerializeField]
    GameManager manager;
    [Header("�^�[������\������text")]
    [SerializeField]
    TextMeshProUGUI turnCountText;
    [Header("���̃X�e�[�W��")]
    [SerializeField]
    GameObject nextStage;
    [Header("�X�e�[�W�Z���N�g��ʂ�")]
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
            turnCountText.text = $"�S�[���܂Őςݏグ�����̂̐���{turn}��";
        }
        else
        {
            result.SetActive(false);
        }
    }
}

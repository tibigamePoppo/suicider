using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audio;

public class Goal : MonoBehaviour
{
    Stage stage;
    [Header("最後のステージかどうか")]
    [SerializeField]
    private bool lastStage = false;
    private void OnEnable()
    {
        stage = FindObjectOfType<Stage>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SeManager.Instance.ShotSe(SeType.ScrollOpen);
            stage.StageGoal(lastStage);
        }
    }
}

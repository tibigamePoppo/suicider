using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Debug.Log($"Goal.lastStage{lastStage}");
            stage.StageGoal(lastStage);
        }
    }
}

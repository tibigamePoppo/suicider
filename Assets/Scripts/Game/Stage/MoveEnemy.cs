using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> targetPoint;
    [Header("敵キャラクターのオブジェクト")]
    [SerializeField]
    private GameObject enemyObject;
    [Header("アニメーション時間")]
    [SerializeField]
    private float time = 10f;
    void Start()
    {
        enemyObject.transform.DOPath(
        path: targetPoint.Select(target => target.transform.position).ToArray(), //移動する座標をオブジェクトから抽出
        duration: time, //移動時間
        pathType: PathType.Linear)
            .SetEase(Ease.Linear)
            .SetLoops(-1,LoopType.Restart);//0.05秒後に通過する場所を見るように;//移動するパスの種類
    }
}

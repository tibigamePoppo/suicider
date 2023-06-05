using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> targetPoint;
    [Header("�G�L�����N�^�[�̃I�u�W�F�N�g")]
    [SerializeField]
    private GameObject enemyObject;
    [Header("�A�j���[�V��������")]
    [SerializeField]
    private float time = 10f;
    void Start()
    {
        enemyObject.transform.DOPath(
        path: targetPoint.Select(target => target.transform.position).ToArray(), //�ړ�������W���I�u�W�F�N�g���璊�o
        duration: time, //�ړ�����
        pathType: PathType.Linear)
            .SetEase(Ease.Linear)
            .SetLoops(-1,LoopType.Restart);//0.05�b��ɒʉ߂���ꏊ������悤��;//�ړ�����p�X�̎��
    }
}

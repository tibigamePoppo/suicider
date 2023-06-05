using UnityEngine;
using DG.Tweening;

public class MoveFloor : MonoBehaviour
{
    [SerializeField]
    private float time;
    [SerializeField]
    private Vector2 movePosition;
    void Start()
    {
        transform.DOMove(movePosition, time)
            .SetRelative()
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Yoyo);
    }
}

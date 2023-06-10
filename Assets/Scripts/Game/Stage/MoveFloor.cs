using UnityEngine;
using DG.Tweening;

public class MoveFloor : MonoBehaviour
{
    [SerializeField]
    private float time;
    [SerializeField]
    private Vector2 movePosition;
    Tweener tweener;
    void Start()
    {
        tweener = transform.DOMove(movePosition, time)
            .SetRelative()
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Yoyo);
    }
    private void OnDestroy()
    {
        tweener.Kill();
    }
}

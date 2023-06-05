using UnityEngine;
using DG.Tweening;

public class AxeTrap : MonoBehaviour
{
    [SerializeField]
    private int startDgree;
    [SerializeField]
    private int returnDgree;
    [SerializeField]
    private float time = 3;
    [SerializeField]
    LoopType type = LoopType.Yoyo;
    [SerializeField]
    Ease ease = Ease.InOutQuad;
    void Start()
    {
        transform.DOLocalRotate(new Vector3(0, 0, startDgree), 0, RotateMode.FastBeyond360);
        transform.DOLocalRotate(new Vector3(0, 0, returnDgree), time, RotateMode.FastBeyond360)
            .SetEase(ease)
            .SetLoops(-1, type);
    }
}

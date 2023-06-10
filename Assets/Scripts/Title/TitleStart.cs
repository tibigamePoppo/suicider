using System.Collections;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;
using Audio;

public class TitleStart : MonoBehaviour
{
    [Header("遷移先のシーン")]
    [SerializeField]
    private SceneObject scene;
    [SerializeField]
    private TextMeshProUGUI TMPro;
    Tweener tweener;
    [Header("明滅基本速度")]
    [SerializeField]
    private float baseSpeed = 1;
    [Header("選択時の明滅速度")]
    [SerializeField]
    private float selectSpeed = 0.5f;
    [Header("選択からシーン時間までの時間")]
    [SerializeField]
    private float waitTime = 1f;
    void Start()
    {
        tweener = TMPro.DOFade(0.0f, baseSpeed)   // アルファ値を0にしていく
                       .SetLoops(-1, LoopType.Yoyo);    // 行き来を無限に繰り返す
        StartCoroutine(ChengeScene());
    }
    /// <summary>
    /// シーン繊維の処理
    /// </summary>
    IEnumerator ChengeScene()
    {
        yield return new WaitUntil(() => Input.anyKey);
        SeManager.Instance.ShotSe(SeType.Select);
        tweener.Kill();
        tweener = TMPro.DOFade(1, 0);   // アルファ値を1にする
        tweener = TMPro.DOFade(0.0f, selectSpeed)   // アルファ値を0にしていく
                       .SetLoops(-1, LoopType.Yoyo);    // 行き来を無限に繰り返す
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(scene);

    }
}

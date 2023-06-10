using System.Collections;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;
using Audio;

public class TitleStart : MonoBehaviour
{
    [Header("�J�ڐ�̃V�[��")]
    [SerializeField]
    private SceneObject scene;
    [SerializeField]
    private TextMeshProUGUI TMPro;
    Tweener tweener;
    [Header("���Ŋ�{���x")]
    [SerializeField]
    private float baseSpeed = 1;
    [Header("�I�����̖��ő��x")]
    [SerializeField]
    private float selectSpeed = 0.5f;
    [Header("�I������V�[�����Ԃ܂ł̎���")]
    [SerializeField]
    private float waitTime = 1f;
    void Start()
    {
        tweener = TMPro.DOFade(0.0f, baseSpeed)   // �A���t�@�l��0�ɂ��Ă���
                       .SetLoops(-1, LoopType.Yoyo);    // �s�����𖳌��ɌJ��Ԃ�
        StartCoroutine(ChengeScene());
    }
    /// <summary>
    /// �V�[���@�ۂ̏���
    /// </summary>
    IEnumerator ChengeScene()
    {
        yield return new WaitUntil(() => Input.anyKey);
        SeManager.Instance.ShotSe(SeType.Select);
        tweener.Kill();
        tweener = TMPro.DOFade(1, 0);   // �A���t�@�l��1�ɂ���
        tweener = TMPro.DOFade(0.0f, selectSpeed)   // �A���t�@�l��0�ɂ��Ă���
                       .SetLoops(-1, LoopType.Yoyo);    // �s�����𖳌��ɌJ��Ԃ�
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(scene);

    }
}

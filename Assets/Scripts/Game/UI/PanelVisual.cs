using UnityEngine;
using Audio;

public class PanelVisual : MonoBehaviour
{
    [Header("�\����؂�ւ���p�l��")]
    [SerializeField]
    private GameObject targetPanel;

    /// <summary>
    /// �p�l���̕\���E��\����؂�ւ���
    /// </summary>
    public void ChangeVisual(bool value)
    {
        if(value)
        {
            SeManager.Instance.ShotSe(SeType.ScrollOpen);
        }
        targetPanel.SetActive(value);
    }
}

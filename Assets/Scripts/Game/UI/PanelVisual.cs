using UnityEngine;

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
        targetPanel.SetActive(value);
    }
}

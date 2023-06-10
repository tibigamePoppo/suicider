using UnityEngine;
using Audio;

public class PanelVisual : MonoBehaviour
{
    [Header("表示を切り替えるパネル")]
    [SerializeField]
    private GameObject targetPanel;

    /// <summary>
    /// パネルの表示・非表示を切り替える
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

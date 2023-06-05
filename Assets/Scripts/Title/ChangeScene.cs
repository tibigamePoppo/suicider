using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    private SceneObject targetScene;

    /// <summary>
    /// target�V�[���ɑJ�ڂ���
    /// </summary>
    public void Change()
    {
        SceneManager.LoadScene(targetScene);
    }
}

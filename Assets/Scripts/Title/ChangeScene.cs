using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    private SceneObject targetScene;

    /// <summary>
    /// targetシーンに遷移する
    /// </summary>
    public void Change()
    {
        SceneManager.LoadScene(targetScene);
    }
}

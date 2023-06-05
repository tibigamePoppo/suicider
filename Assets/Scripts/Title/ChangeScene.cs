using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    private SceneObject targetScene;

    /// <summary>
    /// targetƒV[ƒ“‚É‘JˆÚ‚·‚é
    /// </summary>
    public void Change()
    {
        SceneManager.LoadScene(targetScene);
    }
}

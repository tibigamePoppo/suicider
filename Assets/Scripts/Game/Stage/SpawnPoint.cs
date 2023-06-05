using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private void OnEnable()
    {
        FindObjectOfType<Stage>().spawnPoint = transform.position;
    }
}

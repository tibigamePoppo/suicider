using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTImer : MonoBehaviour
{
    [Header("éQè∆å≥")]
    [SerializeField]
    private GameObject activationObject;
    [Header("êîíl")]
    [SerializeField]
    private float timer;
    void Start()
    {
        StartCoroutine(activeTime());
    }

    IEnumerator activeTime()
    {
        yield return new WaitForSeconds(timer);
        activationObject.SetActive(true);
    }
}

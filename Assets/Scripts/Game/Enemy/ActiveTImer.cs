using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTImer : MonoBehaviour
{
    [Header("参照元")]
    [SerializeField]
    private GameObject activationObject;
    [Header("数値")]
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

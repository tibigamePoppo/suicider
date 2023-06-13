using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTImer : MonoBehaviour
{
    [Header("�Q�ƌ�")]
    [SerializeField]
    private GameObject activationObject;
    [Header("���l")]
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseParticals : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(Close());
    }

    private IEnumerator Close()
    {
        yield return new WaitForSeconds(2.5f);
        this.gameObject.SetActive(false);
    }
}

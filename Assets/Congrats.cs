using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Congrats : MonoBehaviour
{

    void Start()
    {
        gameObject.SetActive(false);
    }

 
    public IEnumerator DisplayCongrats()
    {
        yield return new WaitForSeconds(0.01f);
        gameObject.SetActive(true);
    }
}

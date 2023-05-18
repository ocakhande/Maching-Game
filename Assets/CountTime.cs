using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountTime : MonoBehaviour
{
    public TextMeshProUGUI counter_text;
    public float time;
    void Start()
    {
        time = 0;
        counter_text.text = "" + time; 
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        int minute = (int)(time / 60);
        int second = (int)(time % 60);
        int salise = (int)((time * 100) % 100);

        counter_text.text = string.Format("{0:00}:{1:00}:{2:00}", minute, second,salise);


    }
}

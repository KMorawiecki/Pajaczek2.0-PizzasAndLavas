using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer = 10;
    public Text time;

    void FixedUpdate()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            time.text = timer.ToString();
        }
        else
        {
            timer = 0;
            time.text = timer.ToString();
        }
    }
}
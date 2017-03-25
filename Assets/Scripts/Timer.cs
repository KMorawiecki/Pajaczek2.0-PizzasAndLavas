using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer = 20;
    public Text time;
    public GameManager Manager;

    void FixedUpdate()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            time.text = timer.ToString();
        }
        else
        {
            Manager.LevelUp();
        }
    }
}
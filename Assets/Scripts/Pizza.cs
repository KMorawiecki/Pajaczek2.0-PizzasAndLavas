using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour
{
    public Wand left;
    public Wand right;
    public GameObject pizzaBody;
    public GameObject gameManager;
    public GameObject timer;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        timer = GameObject.Find("Timer");
    }

    void EatPizza()
    {
        DestroyObject(transform.gameObject);
        AddPoints();
    }

    void Update()
    {
        if (Mathf.Abs(left.transform.position.z - transform.position.z) < 0.1 && Mathf.Abs(left.transform.position.x - transform.position.x) < 0.1)
            EatPizza();
        if (Mathf.Abs(right.transform.position.z - transform.position.z) < 0.1 && Mathf.Abs(right.transform.position.x - transform.position.x) < 0.1)
            EatPizza();
    }
    void AddPoints()
    {
        gameManager.GetComponent<GameManager>().points++;
        gameManager.GetComponent<GameManager>().pizzas_lvl++;
        if (gameManager.GetComponent<GameManager>().pizzas_lvl % 3 == 0 && timer.GetComponent<Timer>().timer > 0)
        {
            gameManager.GetComponent<GameManager>().points++;
            gameManager.GetComponent<GameManager>().pizzas_lvl = 0;
        }
        if (timer.GetComponent<Timer>().timer == 0)
        {
            gameManager.GetComponent<GameManager>().pizzas_lvl = 0;
        }
    }
}

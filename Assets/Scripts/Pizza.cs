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
    private GameManager manager;
    

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        manager = gameManager.GetComponent<GameManager>();
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
        manager.points++;
        manager.pizzas_lvl++;
        if (manager.pizzas_lvl == 3)
            manager.LevelUp();

    }
}

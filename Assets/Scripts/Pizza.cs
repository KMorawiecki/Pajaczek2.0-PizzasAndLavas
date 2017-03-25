using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour
{
    public Wand left;
    public Wand right;
    public GameObject pizzaBody;

    void EatPizza()
    {
        DestroyObject(transform.gameObject);
    }

    void Update()
    {
        if (Mathf.Abs(left.transform.position.z - transform.position.z) < 0.1 && Mathf.Abs(left.transform.position.x - transform.position.x) < 0.1)
            EatPizza();
        if (Mathf.Abs(right.transform.position.z - transform.position.z) < 0.1 && Mathf.Abs(right.transform.position.x - transform.position.x) < 0.1)
            EatPizza();
    }
}

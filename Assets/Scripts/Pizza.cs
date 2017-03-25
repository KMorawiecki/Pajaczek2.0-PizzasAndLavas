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

    void OnCollisionEnter(Collision col)
    {
        EatPizza();
    }
}

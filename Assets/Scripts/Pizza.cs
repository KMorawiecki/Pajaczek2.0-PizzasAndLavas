using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour
{
    public Wand left;
    public Wand right;
    public GameObject pizzaBody;
    public SphereCollider pizzaCol;

    public void Start()
    {
        //TODO: przyporzadkowac kontrolery
        pizzaCol = GetComponent<SphereCollider>();
    }

    void EatPizza()
    {
        DestroyObject(pizzaBody, 5);
    }

    void OnCollisionEnter(SphereCollider col)
    {
        EatPizza();
    }
}

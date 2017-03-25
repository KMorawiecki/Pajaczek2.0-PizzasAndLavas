using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    public Material lava;
    public Material earth;
    public GameObject terrainPrefab;
    int a;

    // Use this for initialization
    void Start()
    {
        foreach (Transform child in transform)
        {
            a = Random.Range(0, 2);
            if (a == 0)
            {
                child.GetComponent<MeshRenderer>().material = lava;
                child.tag = "Lava";
            }
            if (a == 1)
            {
                child.GetComponent<MeshRenderer>().material = earth;
                child.tag = "Earth";
                //var terrain = Instantiate(terrainPrefab, child.position, child.rotation, transform);
            }
            if (child.transform.position == Vector3.zero)
            {
                child.GetComponent<MeshRenderer>().material = earth;
                child.tag = "Earth";
                //Instantiate(terrainPrefab, child.position, child.rotation, transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

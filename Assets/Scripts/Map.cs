using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    public Material lava;
    public Material earth;
    public GameObject terrainPrefab;
    int a;
    int b;
    int x, y, z;
    public GameObject bullet;
    public GameObject headset;

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
                //child.gameObject.AddComponent<ParticleSystem>();
                //child.GetComponent<ParticleSystem>().startSize = 0.05f;
                //child.GetComponent<ParticleSystemRenderer>().material = lava;
                child.gameObject.GetComponent<BoxCollider>(); 
            }
            if (a == 1)
            {
                child.GetComponent<MeshRenderer>().material = earth;
                child.tag = "Earth";
            }
            if (child.transform.position == Vector3.zero)
            {
                child.GetComponent<MeshRenderer>().material = earth;
                child.tag = "Earth";
            }
        }
        foreach (Transform child in transform)
        {
            if(child.gameObject.tag == "Earth")
            {
                var terrain = Instantiate(terrainPrefab, child.position, child.rotation, transform);
            }
        }
        StartCoroutine(Bullets());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator Bullets()
    {
        while (true)
        {
            b = Random.Range(10, 15);
            Vector3 v = new Vector3(Random.Range(0, 20), 2, Random.Range(0, 20)); //Why it's instantiated in another position?
            var bul = Instantiate(bullet, v, transform.rotation, transform);
            var dir = headset.transform.position - bul.transform.position;
            dir = dir.normalized;
            bul.GetComponent<Rigidbody>().AddForce(dir * 100);
            yield return new WaitForSeconds(b);
        }
    }
}

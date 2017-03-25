using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    public Material lava;
    public Material earth;
    public GameObject terrainPrefab;
    public GameObject lavaPrefab;
    int a;
    int b;
    int x, y, z;
    public GameObject bullet;
    public GameObject headset;
    public Vector3 vector = new Vector3(0f, 0f, 0f);

    // Use this for initialization
    void Start()
    {
        Generate(vector);
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
            bul.GetComponent<Rigidbody>().AddForce(dir * 400);
            yield return new WaitForSeconds(b);
        }
    }

    public void Generate(Vector3 vector)
    {
        foreach (Transform child in transform)
        {
            a = Random.Range(0, 2);
            if (a == 0 && child.transform.position != vector)
            {
                child.GetComponent<MeshRenderer>().material = lava;
                child.tag = "L";
                child.gameObject.AddComponent<ParticleSystem>();
                child.GetComponent<ParticleSystem>().startSize = 0.05f;
                child.GetComponent<ParticleSystemRenderer>().material = lava;
                child.gameObject.GetComponent<BoxCollider>();
            }
            if (a == 1)
            {
                child.GetComponent<MeshRenderer>().material = earth;
                child.tag = "E";
            }

            if (child.transform.position == vector)
            {
                child.GetComponent<MeshRenderer>().material = earth;
                child.tag = "E";
            }
        }
        foreach (Transform child in transform)
        {
            if (child.gameObject.tag == "Earth" || child.gameObject.tag == "Lava")
                Destroy(child.gameObject);
            if (child.gameObject.tag == "E")
            {
                var terrain = Instantiate(terrainPrefab, child.position, child.rotation, transform);
                child.gameObject.tag = "Earth";
            }
            if (child.gameObject.tag == "L")
            {
                var terrain = Instantiate(lavaPrefab, child.position, child.rotation, transform);
                child.gameObject.tag = "Lava";
            }
        }
        StartCoroutine(Bullets());
    }
}

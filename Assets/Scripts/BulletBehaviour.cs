using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {

    public GameObject gameManager;
    public GameObject cright;
    public GameObject cleft;
    public GameObject headset;
    public int life;
    // Use this for initialization
    void Start () {
        gameManager = GameObject.Find("GameManager");
        headset = GameObject.Find("Camera (head)");
        cright = GameObject.Find("Controller (right)");
        cleft = GameObject.Find("Controller (left)");
	}
	
	// Update is called once per frame
	void Update () {

    }
    
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wand")
        {
            Destroy(gameObject);
        }

    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Bang")
        {
            var life = gameManager.GetComponent<GameManager>().GetLife();
            gameManager.GetComponent<GameManager>().SetLife(life - 1); //Doesn't work
            Destroy(gameObject);
        }
    }
    
}

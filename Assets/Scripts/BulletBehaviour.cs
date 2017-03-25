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
	

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Wand") {
            Debug.Log("Wand");
            Destroy(gameObject);
        }
        if (collider.gameObject.tag == "Bang")
        {
            Debug.Log("Bang");
            var life = gameManager.GetComponent<GameManager>().GetLife();
            gameManager.GetComponent<GameManager>().SetLife(life - 1); //Doesn't work
            Destroy(gameObject);
        }
    }
    
}

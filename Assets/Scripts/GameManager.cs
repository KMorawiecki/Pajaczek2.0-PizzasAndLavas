using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text lifeCounter;
    public Text timer;
    public GameObject map;
    public Wand left;
    public Wand right;
    public Camera mainCam;
    public int life = 10;
    public int points = 0;
    public int pizzas_lvl = 0;
    private List<Pizza> pizzaList;
    public GameObject pizzaPrefab;

    private float invincibleTime = 2;
    private IEnumerator coroutine;

	void Start ()
    {
        points = pizzas_lvl = 0;
        coroutine = WatchingSteps(invincibleTime);
        StartCoroutine(coroutine);
        pizzaList = new List<Pizza>();
        PlacePizzas();
    }
	
	void Update ()
    {
        if (life <= 0)
            GameOver();
        lifeCounter.text = "Life: " + life.ToString();
	}

    private IEnumerator WatchingSteps(float time)
    {
        while (true)
        {
            if (CheckIfOnLava(mainCam))
            {
                life -= 1;
                yield return new WaitForSeconds(time);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private bool CheckIfOnLava(Camera cam)
    {
        foreach(Transform child in map.transform)
        {
            if (child.tag == "Lava")
                if (Mathf.Abs(child.position.z - cam.transform.position.z) < 0.5 || Mathf.Abs(child.position.x - cam.transform.position.x) < 0.5)
                    return true;
        }
        return false;
    }

    private void GameOver()
    {
        //TODO: plan game over 
    }

    public int GetLife()
    {
        return life;
    }
    public void SetLife(int life)
    {
        this.life = life;
    }

    private void PlacePizzas()
    {
        List<Transform> earthPlaces = new List<Transform>();
        foreach (Transform child in map.transform)
            if (child.tag == "Earth" && child.transform.position != Vector3.zero)
                earthPlaces.Add(child);
        int transInt = Random.Range(0, earthPlaces.Count - 1);
        Transform firstPizza = earthPlaces[transInt];
        earthPlaces.RemoveAt(transInt);
        transInt = Random.Range(0, earthPlaces.Count - 1);
        Transform secondPizza = earthPlaces[transInt];
        earthPlaces.RemoveAt(transInt);
        transInt = Random.Range(0, earthPlaces.Count - 1);
        Transform thirdPizza = earthPlaces[transInt];
        earthPlaces.RemoveAt(transInt);
        GameObject pizza_no1;
        pizza_no1 = Instantiate(pizzaPrefab, new Vector3(firstPizza.position.x, firstPizza.position.y + 1, firstPizza.position.z), Quaternion.identity) as GameObject;
        var pizza_no1_instance = pizza_no1.GetComponent<Pizza>();
        GameObject pizza_no2;
        pizza_no2 = Instantiate(pizzaPrefab, new Vector3(secondPizza.position.x, secondPizza.position.y + 1, secondPizza.position.z), Quaternion.identity) as GameObject;
        var pizza_no2_instance = pizza_no1.GetComponent<Pizza>();
        GameObject pizza_no3;
        pizza_no3 = Instantiate(pizzaPrefab, new Vector3(thirdPizza.position.x, thirdPizza.position.y + 1, thirdPizza.position.z), Quaternion.identity) as GameObject;
        var pizza_no3_instance = pizza_no1.GetComponent<Pizza>();
    }
}

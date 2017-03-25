using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text lifeCounter;
    public Text pointCounter;
    public Timer timer;
    public GameObject map;
    public GameObject pointsPanel;
    public GameObject lifePanel;
    public GameObject timePanel;
    public Wand left;
    public Wand right;
    public Camera mainCam;
    public int life = 30;
    public int points = 0;
    public int pizzas_lvl = 0;
    private List<Pizza> pizzaList;
    public GameObject pizzaPrefab;
    public Map Map;
    private Vector3 startingVector = new Vector3(0f,0f,0f);
    public GameObject messagePanel;

    private float invincibleTime = 2;
    private IEnumerator coroutine;

	void Start ()
    {
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
        pointCounter.text = "Points: " + points.ToString();
        if (Input.GetKey(KeyCode.RightArrow))
        {
            map.transform.Translate(new Vector3(-5 * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            map.transform.Translate(new Vector3(5 * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            map.transform.Translate(new Vector3(0, 0, 5 * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            map.transform.Translate(new Vector3(0, 0, -5 * Time.deltaTime));
        }
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
                if (Mathf.Abs(child.position.z - cam.transform.position.z) < 0.25 || Mathf.Abs(child.position.x - cam.transform.position.x) < 0.25)
                    return true;
        }
        return false;
    }

    public void GameOver()
    {
        messagePanel.SetActive(true);
        messagePanel.GetComponentInChildren<Text>().text = "You lose. You\n have gained: " + points.ToString()+ " points";
        StopAllCoroutines();
        pointsPanel.SetActive(false);
        lifePanel.SetActive(false);
        timePanel.SetActive(false);


        foreach (Transform gameobject in map.transform)
        {
            Destroy(gameobject.gameObject);
        }
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
            if (child.tag == "Earth" && child.transform.position != startingVector)
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
        pizza_no1 = Instantiate(pizzaPrefab, new Vector3(firstPizza.position.x, firstPizza.position.y + 0.5f, firstPizza.position.z), Quaternion.identity) as GameObject;
        var pizza_no1_instance = pizza_no1.GetComponent<Pizza>();
        GameObject pizza_no2;
        pizza_no2 = Instantiate(pizzaPrefab, new Vector3(secondPizza.position.x, secondPizza.position.y + 0.5f, secondPizza.position.z), Quaternion.identity) as GameObject;
        var pizza_no2_instance = pizza_no1.GetComponent<Pizza>();
        GameObject pizza_no3;
        pizza_no3 = Instantiate(pizzaPrefab, new Vector3(thirdPizza.position.x, thirdPizza.position.y + 0.5f, thirdPizza.position.z), Quaternion.identity) as GameObject;
        var pizza_no3_instance = pizza_no1.GetComponent<Pizza>();
    }

    public void LevelUp()
    {
        foreach(Transform child in map.transform)
            if(Mathf.Abs(child.position.x - mainCam.transform.position.x) < 0.5 && Mathf.Abs(child.position.z - mainCam.transform.position.z) < 0.5)
            {
                startingVector = new Vector3(child.position.x, child.position.y, child.position.z);
                Map.Generate(startingVector);
                break;
            }
        PlacePizzas();
        int timePoints = (int)timer.timer;
        points += timePoints; 
        timer.timer = 20f;
    }
}

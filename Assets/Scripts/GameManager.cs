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
    public int life = 3;
    public int points = 0;

    private float invincibleTime = 2;
    private IEnumerator coroutine;

	void Start ()
    {
        coroutine = WatchingSteps(invincibleTime);
        StartCoroutine(coroutine);
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
            if (CheckIfOnLava(left) || CheckIfOnLava(right))
            {
                life -= 1;
                yield return new WaitForSeconds(time);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private bool CheckIfOnLava(Wand wand)
    {
        foreach(Transform child in map.transform)
        {
            if (child.tag == "Lava")
                if (Mathf.Abs(child.position.z - wand.transform.position.z) < 0.25 || Mathf.Abs(child.position.y - wand.transform.position.y) < 0.25)
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
}

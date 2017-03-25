using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Timer : MonoBehaviour
{
    private float timer = 10;
    private Text time;
    	
	// Update is called once per frame
	void FixedUpdate ()
    {
        timer -= Time.deltaTime;
        time.text = timer.ToString(); 
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour {
    public float minX = -16.0f;
    public float maxX = 16.0f;
    public float speed = 3;
    private int direction = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float x = transform.position.x;
        if (x > maxX)
            direction = -1;
        else if (x < minX)
            direction = 1;
        
        transform.Translate(direction * speed * Time.deltaTime, 0, 0);
		
	}
}

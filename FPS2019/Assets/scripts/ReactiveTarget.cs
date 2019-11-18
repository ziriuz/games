﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    internal void ReactToHit()
    {
        WanderingAI behaviur = GetComponent<WanderingAI>();
        
        if (behaviur!=null)
            behaviur.setAlive(false);

        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        this.transform.Rotate(-75, 0, 0);


        yield return new WaitForSeconds(1.5f);

        Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (OpenCVFaceDetection.NormalizedFacePositions.Count == 0)
            return;

        //Debug.Log("fase position:" + OpenCVFaceDetection.NormalizedFacePositions[0].x);
        transform.Rotate(0, -1 * OpenCVFaceDetection.NormalizedFacePositions[0].x * speed, 0, Space.World);
	}
}

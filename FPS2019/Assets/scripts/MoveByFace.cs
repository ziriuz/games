using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByFace : MonoBehaviour
{
    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OpenCVFaceDetection.NormalizedFacePositions.Count == 0)
            return;

        //Debug.Log("fase position:" + OpenCVFaceDetection.NormalizedFacePositions[0].x);
        transform.Translate(-1.0f * OpenCVFaceDetection.NormalizedFacePositions[0].x * speed, 0, 0, Space.World);
    }
}

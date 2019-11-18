using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

    public enum RotationAxes
    {
        XY = 0,
        X = 1,
        Y = 2
    }

    public RotationAxes axes = RotationAxes.X;
    public float sensitivityHor = 9;
    public float sensitivityVert = 4;
    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;
    private float _rotationX = 0;

    // Use this for initialization
    void Start () {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }
		
	}
	
	// Update is called once per frame
	void Update () {
        if (axes == RotationAxes.X)
        {
            // это поворот в горизонтальной плоскости
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0, Space.World);
        }
        else if (axes == RotationAxes.Y)
        {
            // это поворот в вертикальной плоскости
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else
        {
            // это комбинированный поворот
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
}

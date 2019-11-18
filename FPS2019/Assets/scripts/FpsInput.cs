using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FpsInput : MonoBehaviour {

    public float speed = 6.0f;
    public float gravity = -9.8f;
    public float pushForce = 3.0f;
    private CharacterController character;
 
	// Use this for initialization
	void Start () {
        character = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        character.Move(movement);
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
    
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body != null && !body.isKinematic)
        {
            
            body.velocity = hit.moveDirection * 3.0f;
            Debug.Log("fpsInput OnControllerColliderHit " + body.velocity.ToString());
        }
    }
}


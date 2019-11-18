using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

    public float speed = 10.0f;
    public int damage = 1;
    public float pushForce = 3.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            player.Hurt(damage);
            Debug.Log("Hit player");
        }
        Destroy(this.gameObject);
    }
    // store collision to use in Update
    void OnCollisionEnter(Collision collision)
    {

        Debug.Log("fireball.collision.relativeVelocity" + collision.relativeVelocity.ToString());
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
        if (collision.relativeVelocity.magnitude > 2)
            Debug.Log("fireball.collision.relativeVelocity" + collision.relativeVelocity.magnitude.ToString());
    }
}

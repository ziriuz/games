using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour {
    [SerializeField] private GameObject fireballPerfab;
    private GameObject fireball;
    private Camera cam;
	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0);
            Ray ray = cam.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    Debug.Log("Hit " + hitObject.name);
                    target.ReactToHit();
                }
                else
                {
                    //StartCoroutine(SphereIndicator(hit.point));
                    if (fireball == null)
                    {
                        fireball = Instantiate(fireballPerfab) as GameObject;
                        fireball.GetComponent<Collider>().isTrigger = false;
                    }
                    fireball.transform.position =
                            transform.TransformPoint(Vector3.forward * 2.5f);
                    fireball.transform.rotation = transform.rotation;
                }

            }
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Application.Quit();
        }

	}
    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }

    void OnGUI()
    {
        int size = 12;
        float posX = cam.pixelWidth / 2 - size / 4;
        float posY = cam.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }
}

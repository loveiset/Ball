using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    float halfW = Screen.width / 2;
    float halfH = Screen.height / 2;

    float smooth = 5.0f;
    float tiltAngle = 30.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        float tiltAroundZ = Input.GetAxis("Mouse X") * tiltAngle * 2;
        float tiltAroundX = Input.GetAxis("Mouse Y") * tiltAngle * -2;
        Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);
        this.transform.position = new Vector3((Input.mousePosition.x - halfW) / halfW, 0, (Input.mousePosition.y - halfH) / halfH);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }
}

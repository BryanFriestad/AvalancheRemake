using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public float scrollCutoff;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(0, player.transform.position.y, -10);
	}
	
	// Update is called once per frame
	void Update () {
		if(player.transform.position.y - transform.position.y > scrollCutoff)
        {
            transform.position = new Vector3(0, player.transform.position.y - scrollCutoff, -10);
        }
        else if(player.transform.position.y - transform.position.y < -scrollCutoff)
        {
            transform.position = new Vector3(0, player.transform.position.y + scrollCutoff, -10);
        }

        transform.position = new Vector3(-player.transform.position.x, transform.position.y, transform.position.z);

        transform.rotation = Matrix4x4.LookAt(transform.position, player.transform.position, Vector3.up).rotation;
    }
}

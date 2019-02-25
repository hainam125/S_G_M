using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var direction = Vector3.zero;
        if (Input.GetKey(KeyCode.A)) direction = Vector2.left;
        else if (Input.GetKey(KeyCode.D)) direction = Vector2.right;
        if (Input.GetKey(KeyCode.W)) direction = Vector2.up;
        else if (Input.GetKey(KeyCode.S)) direction = Vector2.down;
        transform.position += direction * speed * Time.deltaTime;
    }
}

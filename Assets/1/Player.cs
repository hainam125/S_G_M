using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public Target target;
    public float y0, x0;
    public float Y;
    private PlayerMoveCoord playerMoveCoord;

	// Use this for initialization
	void Start () {
        playerMoveCoord = new PlayerMoveCoord(-2, 2, Y, x0, y0);
	}
	
	// Update is called once per frame
	void Update () {
        float y1 = target.transform.position.y;
        if (Mathf.Abs(y1) <= Mathf.Abs(y0))
        {
            float x1 = target.transform.position.x;
            var pos = playerMoveCoord.CoordWithLineTo(x1, y1);
            transform.position = new Vector3(pos.x, pos.y);
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour {
    public Target target;
    public float x0, y0;
    public float X;
    private PlayerMoveCoord2 playerMoveCoord;

    // Use this for initialization
    void Start()
    {
        playerMoveCoord = new PlayerMoveCoord2(-2, 2, X, y0, x0);
    }

    // Update is called once per frame
    void Update()
    {
        float x1 = target.transform.position.x;
        if (Mathf.Abs(x1) <= Mathf.Abs(x0))
        {
            float y1 = target.transform.position.y;
            var pos = playerMoveCoord.CoordWithLineTo(y1, x1);
            transform.position = new Vector3(pos.x, pos.y);
        }
    }
}

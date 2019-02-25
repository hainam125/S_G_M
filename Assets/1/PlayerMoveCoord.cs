using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveCoord {
    private float X1, X2, Y;
    private float y0, x0;

    public PlayerMoveCoord(float x1, float x2, float y, float x0, float y0)
    {
        X1 = x1;
        X2 = x2;
        Y = y;
        this.x0 = x0;
        this.y0 = y0;
    }

    //intersect with y = const
    private Vector2 CoordWithHorizontalLine(float x1)
    {
        //check this
        if (x1 < X1) return new Vector2(X1, y0);
        else if (x1 > X2) return new Vector2(X2, y0);
        else return new Vector2(x1, y0);
    }

    //intersect with x = const
    private Vector2 CoordWithVerticalLine(float y1)
    {
        if (Mathf.Abs(y1 - y0) > Mathf.Abs( Y - y0)) return new Vector2(x0, Y);
        else return new Vector2(x0, y1);
    }

    //intersect with y = ax + b
    private Vector2 CoordWithNormalLine(float a, float b, float y1, float x1)
    {
        float x = (Y - b) / a;
        if (x < X1 && x1 < X1)
        {
            return new Vector2(X1, a * X1 + b);
        }
        else if (x > X2 && x1 > X2)
        {
            return new Vector2(X2, a * X2 + b);
        }
        else if(Mathf.Abs(y1 - y0) < Mathf.Abs(Y - y0))
        {
            return new Vector2((y1 - b) / a, y1);
        }
        else
        {
            return new Vector2(x, Y);
        }
    }

    public Vector2 CoordWithLineTo(float x1, float y1)
    {
        Vector2 pos = Vector2.zero;
        if (x0 == x1)
        {
            pos = CoordWithVerticalLine(y1);
        }
        else if (y0 == y1)
        {
            pos = CoordWithHorizontalLine(x1);
        }
        else
        {
            //y = ax + b go (x0, y0) and (x1, y1)
            float a = (y0 - y1) / (x0 - x1);
            float b = (x0 * y1 - x1 * y0) / (x0 - x1);
            pos = CoordWithNormalLine(a, b, y1, x1);
        }
        return pos;
    }
}

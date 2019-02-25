using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveCoord2 {
    private float Y1, Y2, X;
    private float x0, y0;

    public PlayerMoveCoord2(float y1, float y2, float x, float y0, float x0)
    {
        Y1 = y1;
        Y2 = y2;
        X = x;
        this.y0 = y0;
        this.x0 = x0;
    }

    //intersect with y = const
    private Vector2 CoordWithHorizontalLine(float x1)
    {
        if (Mathf.Abs(x1 - x0) > Mathf.Abs(X - x0)) return new Vector2(X, y0);
        else return new Vector2(x1, y0);
    }

    //intersect with x = const
    private Vector2 CoordWithVerticalLine(float y1)
    {
        if (y1 < Y1) return new Vector2(x0, Y1);
        else if (y1 > Y2) return new Vector2(x0, Y2);
        else return new Vector2(x0, y1);
    }

    //intersect with y = ax + b
    private Vector2 CoordWithNormalLine(float a, float b, float x1, float y1)
    {
        float y = a * X + b;
        if (y < Y1 && y1 < Y1)
        {
            return new Vector2((Y1 - b) / a, Y1);
        }
        else if (y > Y2 && y1 > Y2)
        {
            return new Vector2((Y2 - b) / a, Y2);
        }
        else if (Mathf.Abs(x1 - x0) < Mathf.Abs(X - x0))
        {
            return new Vector2(x1, x1 * a + b);
        }
        else
        {
            return new Vector2(X, y);
        }
    }

    public Vector2 CoordWithLineTo(float y1, float x1)
    {
        Vector2 pos = Vector2.zero;
        if (y0 == y1)
        {
            pos = CoordWithHorizontalLine(x1);
        }
        else if (x0 == x1)
        {
            pos = CoordWithVerticalLine(y1);
        }
        else
        {
            //y = ax + b go (x0, y0) and (x1, y1)
            float a = (y0 - y1) /(x0 - x1) ;
            float b = (y1 * x0 - y0 * x1) / (x0 - x1);
            pos = CoordWithNormalLine(a, b, x1, y1);
        }
        return pos;
    }
}

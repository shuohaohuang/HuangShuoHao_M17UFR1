using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

[System.Serializable]
public struct CheackPoint
{
    public float x;
    public float y;
    public string level;

    public CheackPoint(float x, float y, string level)
    {
        this.x = x;
        this.y = y;
        this.level = level;
    }
}

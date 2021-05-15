using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileNode : TileData, IComparable {

    public TileNode Parent;
    public int Cost;
    public int DistanceToTarget;

    int oldState;

    public void SetupTempState(int newState) {
        oldState = state;
        SetState(newState);
    }

    public void RevertTempState () {
        SetState(oldState);
    }

    public TileNode(int x, int y, int state) : base(x, y, state) { }

    public override bool Equals(object obj)
    {
        TileNode data = obj as TileNode;
        if (data == null) return false;
        return data.pos.x == pos.x && data.pos.y == pos.y && data.pos.z == pos.z;
    }

    public override int GetHashCode()
    {
        return pos.x + pos.y + pos.z;
    }
    public float F
    {
        get
        {
            if (DistanceToTarget != -1 && Cost != -1)
                return DistanceToTarget + Cost;
            else
                return -1;
        }
    }

    public int CompareTo(object obj)
    {
        TileNode other = obj as TileNode;
        return F.CompareTo(other.F);
    }
}

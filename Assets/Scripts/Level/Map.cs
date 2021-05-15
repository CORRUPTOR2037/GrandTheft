using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class Path : LinkedList<TileNode> {
    public int Cost {
        get { return Count; }
    }
    public override string ToString() {
        string a = "";
        foreach (TileNode d in this) {
            a += d.x + " " + d.y + "/";
        }
        return a;
    }
};

public class Map : MonoBehaviour {

    public Tilemap tilemap;

    public MainCharacter hero;

    bool TrueStage = false;

    TileNode[,] tiles;
    MapEnter Enter;
    Path TruePath, FalsePath;

    string ColorVariant;

    public float tileDeleteMP = 0.4f;

    // Use this for initialization
    void Start () {
        TileNode.map = FindObjectOfType<Tilemap>();
        Entity.tilemap = TileNode.map;

        Vector2Int pos = Enter.Position;
        hero.SetPosition(pos.x, pos.y, 0);
        hero.transform.parent = transform;
	}

    // Update is called once per frame
    void FixedUpdate () {
        
	}

    Path GetPath(int startX, int startY, int endX, int endY) {
        TileNode start = tiles[startX, startY];
        TileNode end = tiles[endX, endY];

        List<TileNode> OpenList = new List<TileNode>();
        List<TileNode> ClosedList = new List<TileNode>();
        TileNode current = start;

        // add start node to Open List
        OpenList.Add(start);

        while (OpenList.Count != 0 && !ClosedList.Contains(end))
        {
            current = OpenList[0];  
            OpenList.Remove(current);
            ClosedList.Add(current);
        }

        // construct path, if end was not closed return null
        if (!ClosedList.Contains(end))
        {
            return null;
        }

        // if all good, return path
        Path result = new Path();
        TileNode temp = current;
        while (temp != start)
        {
            result.AddFirst(temp);
            temp = temp.Parent;
        }
        result.AddFirst(start);
        return result;
    }
}

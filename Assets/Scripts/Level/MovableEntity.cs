using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MovableEntity : Entity {

    protected List<Vector2Int> history = new List<Vector2Int>();

    public int PathLength { get { return history.Count; } }

    public void SetNewPath (int startX, int startY) {
        history.Clear();
    }

    public void MoveLeft () {
        x--;
        StartCoroutine("MoveAnimation", "left");
    }

    public void MoveRight () {
        x++;
        StartCoroutine("MoveAnimation", "right");
    }

    public void MoveTop () {
        y++;
        StartCoroutine("MoveAnimation", "top");
    }

    public void MoveBottom () {
        y--;
        StartCoroutine("MoveAnimation", "bottom");
    }

}

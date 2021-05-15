using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Enemy : MovableEntity {

    public void SetPosition (int x, int y) {
        if (this.x > x) MoveLeft();
        else if (this.x < x) MoveRight();
        else if (this.y > y) MoveBottom();
        else if (this.y < y) MoveTop();
        //else throw new System.Exception("Where are you going? ");
    }

    public void Die () {

    }
}

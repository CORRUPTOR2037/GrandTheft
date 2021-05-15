using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEnter : TileNode {

    int radius = 1;
    public MapEnter(int x) : base(x, -1, 3) {
        Name = "platform";
        filled = true;
    }

    public void Draw () {
        int oldX = x; int oldY = y;
        for (int i = -radius; i <= radius; i++)
            for (int j = -1; j < 1; j++) {
                pos = new Vector3Int(oldX + i, oldY + j, 0);
                Update();
            }
        pos = new Vector3Int(oldX, oldY, 0);
    }

    public override bool CanStandOn (int x, int y) {
        return this.x - radius <= x && this.x + radius >= x && (this.y == y || this.y - 1 == y);
    }
}

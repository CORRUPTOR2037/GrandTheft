using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MainCharacter : MovableEntity {

    public bool IsAlive { get; private set; }

	// Use this for initialization
	void Awake () {

    }

    void Start () {
        IsAlive = true;
        onTrigger += x => {

        };
    }

    public void Die () {
        IsAlive = false;
        GameState.Instance.OnDie();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameState : MonoBehaviour {
    public static GameState Instance { get; private set; }

    void Start () {
        Instance = this;
        StartCoroutine("StartGame");
    }

    public void OnDie () {
        StartCoroutine("DieActions");
    }

    public void Restart () {

    }

    private IEnumerator DieActions () {
        yield break;
    }

    public IEnumerator StartGame () {
        yield break;
    }
}

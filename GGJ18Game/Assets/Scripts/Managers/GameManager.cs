﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {

    [SerializeField]
    public BallSpawner ballSpawner;

    public override void Init()
    {
        ballSpawner.Init();
    }

    public void StartGame()
    {
        ballSpawner.StartSpawning();
    }

    public void QuitFromPause()
    {
        ballSpawner.StopSpawning();
    }

}

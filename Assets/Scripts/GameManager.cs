using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Action OnGameStart;

    public Action OnGameOver;

    public Action OnAddScore;

    protected override void Awake()
    {
        base.Awake();
    }
 
}

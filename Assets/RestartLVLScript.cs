using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartLVLScript : MonoBehaviour
{
    public Game Game;
    public LoseFieldScoreScreen UILose;
    void Awake()
    {
        Game.ReloadLevel();
    }

   
}

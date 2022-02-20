using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreCount : MonoBehaviour
{
    public Text Text;
    public Game Game;

    private void Update()
    {
        Text.text = (Game.Score).ToString();
    }
}

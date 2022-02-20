using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameUI : MonoBehaviour
{
    public Game Game;
    public Text CurrentLevelText;
    public TMPro.TextMeshProUGUI BestScoreText;
    public LoseFieldScoreScreen LoseUI;

    private void Awake()
    {
        CurrentLevelText.text = (Game.LevelIndex + 1).ToString ();
        BestScoreText.text = LoseUI.BestScoreText.text;
        CurrentLevelText.text = ("Level " + (Game.LevelIndex + 1)).ToString();
        
        
    }
   
}

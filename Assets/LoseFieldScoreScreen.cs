using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseFieldScoreScreen : MonoBehaviour
{
    
    public TMPro.TextMeshProUGUI BestScoreText;
    public TMPro.TextMeshProUGUI CurrentScoreText;
    public Text CurrentLevelText;
    public Game Game;
    public GameObject LoseField;
    public Text FinishText;
    
    
    

    
    private void Awake()
    {
        CurrentScore = Game.Score;
        BestScore = Mathf.Max(BestScore, CurrentScore);
        CurrentScoreText.text = CurrentScore.ToString();
        BestScoreText.text = BestScore.ToString ();
        CurrentLevelText.text = ("Level " + (Game.LevelIndex + 1)).ToString();
        PlayerPrefs.Save();
        FinishText.enabled = false;
        
    }
    internal int BestScore
    {
        get => PlayerPrefs.GetInt(BestScoreKey, 0);
        private set
        {
            PlayerPrefs.SetInt(BestScoreKey, value);
            PlayerPrefs.Save();
        }
    }
    private const string BestScoreKey = "BestScore";



    private int CurrentScore;
    
    public void LoseUI ()
    {

        
        LoseField.gameObject.SetActive(true);
        

    }
    
}

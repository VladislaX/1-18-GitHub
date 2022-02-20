using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public PlayerControls Controls;
    public LoseFieldScoreScreen UILose;

    private void Awake()
    {
        Score = 0;
    }
    public enum State
    {
        Playing,
        Won,
        Loss,
    }
    public State CurrentState { get; private set; }
    public void OnPlayerDied()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Loss;
        Controls.enabled = false;
        Debug.Log("Game Over");
        UILose.LoseUI();
        
        
    }

    public void OnPlayerReackFinish()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Won;
        LevelIndex++;
        Controls.enabled = false;
        Debug.Log("You Won!");
        UILose.LoseUI();
        UILose.FinishText.enabled = true;
        
    }
    public void ScoreCounting()
    {
        Score++;
        
    }
    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }
    private const string LevelIndexKey = "LevelIndex";
    
    public int Score
    {
        get => PlayerPrefs.GetInt(ScoreKey, 0);
        private set
        {
            PlayerPrefs.SetInt(ScoreKey, value);
        }
    }
    private const string ScoreKey = "Score";

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Score = 0;
    }
}
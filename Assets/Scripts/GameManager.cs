using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static event Action<GameState> OnGameStateChanged;

    public GameState state;

    public int currentScore, highScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        //Debug.LogWarning("current score " + currentScore.ToString());
        //Debug.LogWarning("high score " + highScore.ToString());
    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch (newState)
        {
            case GameState.MainMenu:
                break;
            case GameState.InGame:
                break;
            case GameState.Death:
                HandleScore();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged(newState);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
        currentScore = 0;
        UpdateGameState(GameState.InGame);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        UpdateGameState(GameState.MainMenu);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void HandleScore()
    {
        if(highScore < currentScore)
        {
            highScore = currentScore;
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Continue()
    {
        Time.timeScale = 1;
    }

}

public enum GameState
{
    MainMenu,
    InGame,
    Death
}

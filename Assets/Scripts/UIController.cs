using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider musicSlider, sfxSlider;
    public GameObject HUD,OptionMenu,ReplayMenu;
    public TMP_Text HUDHighScoreText;
    public TMP_Text replayHighScoreText;
    public TMP_Text replayCurrentScoreText;

    public Button mButton;
    public Button sButton;

    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    private void Start()
    {
        if(GameManager.instance.state == GameState.InGame)
        {
            HUDHighScoreText.text = "High Score : " + GameManager.instance.highScore.ToString();
        }
        if(GameManager.instance.state == GameState.MainMenu || GameManager.instance.state == GameState.InGame)
        {
            if (!AudioManager.instance.musicEnabled) SwitchColor(mButton);
            if (!AudioManager.instance.sfxEnabled) SwitchColor(sButton);
        }
    }

    private void GameManagerOnGameStateChanged(GameState state)
    {
        if(GameManager.instance.state == GameState.Death)
        {
            replayHighScoreText.text = "High Score : " + GameManager.instance.highScore.ToString();
            replayCurrentScoreText.text = "Current Score : " + GameManager.instance.currentScore.ToString();
            ReplayMenu.SetActive(state == GameState.Death);
        }

        
    }

    public void ToggleMusic()
    {
        AudioManager.instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        AudioManager.instance.ToggleSFX();
    }

    public void MusicVolume()
    {
        AudioManager.instance.MusicVolume(musicSlider.value);
    }

    public void SFXVolume()
    {
        AudioManager.instance.SFXVolume(sfxSlider.value);
    }

    public void PlayGame()
    {
        GameManager.instance.PlayGame();
    }

    public void MainMenu()
    {
        GameManager.instance.MainMenu();
    }

    public void QuitGame()
    {
        GameManager.instance.QuitGame();    
    }

    public void Pause()
    {
        GameManager.instance.Pause();
    }

    public void Continue()
    {
        GameManager.instance.Continue();
    }

    public void PlayUI(string name)
    {
        AudioManager.instance.PlayUI(name);
    }

    public void SwitchColor(Button button)
    {
        if(button.image.color == Color.white)
        {
            button.image.color = Color.red;
            if(button.name == "MusicButton") AudioManager.instance.musicEnabled = false;
            if(button.name == "SFXButton") AudioManager.instance.sfxEnabled = false;
        }
        else
        {
            button.image.color = Color.white;
            if (button.name == "MusicButton") AudioManager.instance.musicEnabled = true;
            if (button.name == "SFXButton") AudioManager.instance.sfxEnabled = true;
        }
    }
}


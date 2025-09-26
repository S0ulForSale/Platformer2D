using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class LevelUiManager : MonoBehaviour
{
    [SerializeField] Health playerHealth;
    [SerializeField] GameObject DeadUI;
    [SerializeField] GameObject WinUI;
   // [SerializeField] GameObject PauseUI;
    [SerializeField] GameObject PlayerUI;
    [SerializeField] Finish finish;

    [SerializeField] GameObject PauseUI;

    private AudioManager audioManager;
    private bool isGameOver = false;
    private bool isWinGame = false;
    private void Start()
    {
        audioManager = AudioManager.Instance;
        DeadUI.SetActive(false);
        WinUI.SetActive(false);
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if(playerHealth.dead && !isGameOver) 
        {
            GameOver();
        }
        if(finish.win && !isWinGame)
        {
            WinGame();
        }
    }
    public void PauseMenu()
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
    }
    private void GameOver()
    {
        isGameOver = true;
        DeadUI.SetActive(true);
        PlayerUI.SetActive(false);
        audioManager.PlaySFX(SFXType.Lose);
    }
    private void WinGame()
    {
        isWinGame = true;
        WinUI.SetActive(true);
        PlayerUI.SetActive(false);
        audioManager.PlaySFX(SFXType.Win);
    }

}

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

    private void Awake()
    {
        DeadUI.SetActive(false);
        WinUI.SetActive(false);
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if(playerHealth.dead) 
        {
            GameOver();
        }
        if(finish.win)
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
        Console.WriteLine("Dead");
        DeadUI.SetActive(true);
        PlayerUI.SetActive(false);
    }
    private void WinGame()
    {
        Console.WriteLine("Win");
        WinUI.SetActive(true);
        PlayerUI.SetActive(false);
    }

}

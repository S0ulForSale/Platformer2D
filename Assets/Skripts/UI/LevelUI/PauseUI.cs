using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    [SerializeField] SceneLoader scene;
    [SerializeField] LevelUiManager levelUiManager;

    public void btContinue()
    {
        Console.WriteLine("Continue");
        levelUiManager.Continue();

    }
    public void btRestart()
    {
        scene.RestartLevel();
    }
    public void btLevels()
    {
        scene.Levels();
    }
    public void btMainMenu()
    {
        scene.MainMenu();
    }
}

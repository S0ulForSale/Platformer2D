using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUi : MonoBehaviour
{
    [SerializeField] SceneLoader scene;
    public void btStart()
    {
        scene.Levels();
    }
    public void btSettings()
    {
        scene.Settings();
    }
    public void btAbout()
    {
        scene.About();
    }
    public void btExit()
    {
        Application.Quit();
    }
}

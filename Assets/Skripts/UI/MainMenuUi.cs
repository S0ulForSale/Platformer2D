using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUi : MonoBehaviour
{
    private SceneLoader scene;
    private AudioManager audioManager;
    private void Start()
    {
        audioManager = AudioManager.Instance;
        scene = SceneLoader.Instanse;
    }
    public void btStart()
    {
        scene.Levels();
        audioManager.PlaySFX(SFXType.ButtonClick);
    }
    public void btSettings()
    {
        scene.Settings();
        audioManager.PlaySFX(SFXType.ButtonClick);
    }
    public void btAbout()
    {
        scene.About();
        audioManager.PlaySFX(SFXType.ButtonClick);
    }
    public void btExit()
    {
        Application.Quit();
        audioManager.PlaySFX(SFXType.ButtonClick);
    }
}

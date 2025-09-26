using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinUI : MonoBehaviour
{
    private SceneLoader scene;
    private AudioManager audioManager;
    private void Start()
    {
        audioManager = AudioManager.Instance;
        scene = SceneLoader.Instanse;
    }
    public void btRestartLvl()
    {
        scene.RestartLevel();
        audioManager.PlaySFX(SFXType.ButtonClick);
    }
    public void NextLvl()
    {
        scene.Lvl2();
        audioManager.PlaySFX(SFXType.ButtonClick);
    }
    public void MainMenu() 
    {
        scene.MainMenu();
        audioManager.PlaySFX(SFXType.ButtonClick);
    }
}

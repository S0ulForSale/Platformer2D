using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadUI : MonoBehaviour
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

    public void btLevels()
    {
        scene.Levels();
        audioManager.PlaySFX(SFXType.ButtonClick);
    }
    public void btMainMenu()
    {
        scene.MainMenu();
        audioManager.PlaySFX(SFXType.ButtonClick);
    }
}

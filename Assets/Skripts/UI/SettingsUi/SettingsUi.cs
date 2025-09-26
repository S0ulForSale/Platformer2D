using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsUi : MonoBehaviour
{
    private SceneLoader scene;
    private AudioManager audioManager;
    private void Start()
    {
        audioManager = AudioManager.Instance;
        scene = SceneLoader.Instanse;
    }

    public void btBack()
    {
        scene.MainMenu();
        audioManager.PlaySFX(SFXType.ButtonClick);
    }
}

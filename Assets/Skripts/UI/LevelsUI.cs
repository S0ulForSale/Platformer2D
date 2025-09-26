using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsUI : MonoBehaviour
{
    private SceneLoader scene;
    private AudioManager audioManager;
    private void Start()
    {
        audioManager = AudioManager.Instance;
        scene = SceneLoader.Instanse;
    }

    public void btLvl1()
    {
        scene.Lvl1();
        audioManager.PlaySFX(SFXType.ButtonClick);
    }
    public void btLvl2()
    {
         scene.Lvl2();
         audioManager.PlaySFX(SFXType.ButtonClick);
    }
    public void btBack()
    {
        scene.MainMenu();
        audioManager.PlaySFX(SFXType.ButtonClick);
    }
    public void btSettings()
    {
        scene.Settings();
        audioManager.PlaySFX(SFXType.ButtonClick);
    }
}

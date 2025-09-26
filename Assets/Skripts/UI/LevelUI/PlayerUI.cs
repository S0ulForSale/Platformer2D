using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] LevelUiManager levelUiManager;
    private SceneLoader scene;
    private AudioManager audioManager;
    private void Start()
    {
        audioManager = AudioManager.Instance;
        scene = SceneLoader.Instanse;
    }

    public void btPause()
    {
        levelUiManager.PauseMenu();
        audioManager.PlaySFX(SFXType.ButtonClick);
    }
}

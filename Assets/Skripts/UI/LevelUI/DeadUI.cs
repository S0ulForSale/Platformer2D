using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadUI : MonoBehaviour
{
    [SerializeField] SceneLoader scene;
    // Start is called before the first frame update
    public void btRestartLvl()
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

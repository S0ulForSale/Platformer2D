using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinUI : MonoBehaviour
{
    [SerializeField] SceneLoader scene;
    // Start is called before the first frame update
    public void btRestartLvl()
    {
        scene.RestartLevel();
    }
    public void NextLvl()
    {
        scene.Lvl2();
    }
    public void MainMenu() 
    {
        scene.MainMenu();
    }
}

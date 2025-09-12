using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsUI : MonoBehaviour
{
    [SerializeField] SceneLoader scene;
    public void btLvl1()
    {
        scene.Lvl1();
    }
    public void btLvl2()
    {
         scene.Lvl2();
    }
    public void btBack()
    {
        scene.MainMenu();
    }
    public void btSettings()
    {
        scene.Settings();
    }
}

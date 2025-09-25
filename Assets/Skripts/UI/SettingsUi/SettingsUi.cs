using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsUi : MonoBehaviour
{
    [SerializeField] SceneLoader scene;

    public void btBack()
    {
        scene.MainMenu();
    }
}

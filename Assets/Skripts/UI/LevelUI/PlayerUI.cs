using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] LevelUiManager levelUiManager;

    public void btPause()
    {
        levelUiManager.PauseMenu();
    }
}

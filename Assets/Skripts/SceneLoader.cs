using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instanse = null;

    public void Awake()
    {
        if(Instanse != null) 
        {
            Destroy(gameObject);
            return;
        }
        Instanse = this;
        DontDestroyOnLoad(gameObject);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Levels()
    {
        SceneManager.LoadScene(1);
    }
    public void Settings()
    {
        SceneManager.LoadScene(2);
    }
    public void About()
    {
        SceneManager.LoadScene(3); 
    }
    public void Lvl1()
    {
        SceneManager.LoadScene(4);
    }
    public void Lvl2()
    {
        SceneManager.LoadScene(5);
    }
}

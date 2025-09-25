using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    private static BackgroundMusicManager instance = null;

    void Awake()
    {
        // Перевіряємо, чи існує вже інший MusicManager
        if (instance != null)
        {
            // Якщо так, знищуємо цей об'єкт, щоб уникнути дублювання
            Destroy(gameObject);
            return;
        }

        // Якщо це перший і єдиний MusicManager, зберігаємо його
        instance = this;

        // "Заморожуємо" об'єкт, щоб він не знищувався при переході між сценами
        DontDestroyOnLoad(gameObject);
    }
}

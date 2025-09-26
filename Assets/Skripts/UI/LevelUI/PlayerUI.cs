using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] LevelUiManager levelUiManager;
    [SerializeField] GameObject textGuideObject;
    [SerializeField] TextMeshProUGUI textGuide;
    [SerializeField] private string initialTutorialText;
    private AudioManager audioManager;

    // Час, через який текст зникне (у секундах)
    public float disappearanceTime = 5.0f;

    
    private void Start()
    {
        audioManager = AudioManager.Instance;
        ShowText(initialTutorialText);
    }

    
    // Публічний метод для відображення тексту
    public void ShowText(string textToShow)
    {
        if (textGuideObject != null && textGuide != null)
        {
            textGuide.text = textToShow;
            textGuideObject.SetActive(true);
            StartCoroutine(HideTextAfterDelay());
        }
    }

    // Корутина, що чекає певний час, а потім приховує текст
    private IEnumerator HideTextAfterDelay()
    {
        yield return new WaitForSeconds(disappearanceTime);
        textGuideObject.SetActive(false);
    }


    public void btPause()
    {
        levelUiManager.PauseMenu();
        audioManager.PlaySFX(SFXType.ButtonClick);
    }
}

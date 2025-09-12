using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthImage;
    [SerializeField] private Image currentHealthImage;

    private void Start()
    {
        totalHealthImage.fillAmount = playerHealth.currentHealth / 10f;
    }
    private void Update()
    {
        currentHealthImage.fillAmount = playerHealth.currentHealth / 10f;

    }
}

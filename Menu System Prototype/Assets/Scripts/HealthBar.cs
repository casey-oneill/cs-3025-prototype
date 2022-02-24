using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Text tooltipText;
    public GameObject tooltip;

    private float targetHealth;
    private float currentHealth;

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
        targetHealth = health;
        currentHealth = health;
    }

    public void SetHealth(float health)
    {
        targetHealth = health;
        tooltipText.text = "Health: " + health.ToString();
    }

    public void ShowTooltip()
    {
        tooltip.SetActive(true);
    }

    public void HideTooltip()
    {
        tooltip.SetActive(false);
    }

    private void Start()
    {
        tooltip.SetActive(false);
    }

    void Update()
    {
        if (currentHealth != targetHealth)
        {
            if (currentHealth < targetHealth)
            {
                currentHealth += 0.1f;
            }
            else
            {
                currentHealth -= 0.1f;
            }

            slider.value = currentHealth;
        }
    }
}

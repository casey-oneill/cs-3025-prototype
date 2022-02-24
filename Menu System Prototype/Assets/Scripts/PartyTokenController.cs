using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyTokenController : MonoBehaviour
{
    public Image portrait;
    public GameObject tooltip;
    public HealthBar healthBar;

    private int maxHealth = 100;

    public void ShowTooltip()
    {
        tooltip.SetActive(true);
    }

    public void HideTooltip()
    {
        tooltip.SetActive(false);
    }

    void Start()
    {
        HideTooltip();

        healthBar.SetMaxHealth(maxHealth);
        Invoke("RandomizeHealth", Random.Range(3, 10));
    }

    void RandomizeHealth()
    {
        healthBar.SetHealth((int)Random.Range(5, maxHealth));
        Invoke("RandomizeHealth", Random.Range(3, 10));
    }
}

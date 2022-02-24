using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenuController : MonoBehaviour
{

    public GameObject soundMenu;
    public GameObject displayMenu;
    public GameObject controlsMenu;

    public void OpenSoundMenu()
    {
        soundMenu.SetActive(true);
        displayMenu.SetActive(false);
        controlsMenu.SetActive(false);
    }

    public void OpenDisplayMenu()
    {
        soundMenu.SetActive(false);
        displayMenu.SetActive(true);
        controlsMenu.SetActive(false);
    }

    public void OpenControlsMenu()
    {
        soundMenu.SetActive(false);
        displayMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    private void Start()
    {
        soundMenu.SetActive(false);
        displayMenu.SetActive(false);
        controlsMenu.SetActive(false);
    }
}

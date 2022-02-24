using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    public enum ItemColours
    {
        BLUE = 0,
        GREEN = 1,
        PURPLE = 2,
        RED = 3
    }

    public GameObject OpenMenuButton;
    public GameObject MainMenu;
    public Image EquippedWeaponImage;
    public Image EquippedArmourImage;

    public Sprite[] WeaponSprites;
    public Sprite[] ArmourSprites;

    public Image[] HotkeyImages;

    public EquippableItem[] Weapons = new EquippableItem[4];
    public EquippableItem[] Armours = new EquippableItem[4];

    private bool isMenuOpen = false;
    private EquippableItem equippedWeapon;
    private EquippableItem equippedArmour;

    private EquippableItem[] hotkeyItems = new EquippableItem[10];

    public void OpenMenu()
    {
        isMenuOpen = true;
        OpenMenuButton.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void CloseMenu()
    {
        isMenuOpen = false;
        OpenMenuButton.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void SetEquippedWeapon(EquippableItem weapon)
    {
        equippedWeapon = weapon;
        EquippedWeaponImage.sprite = weapon.Image;
    }

    public void SetEquippedArmour(EquippableItem armour)
    {
        equippedArmour = armour;
        EquippedArmourImage.sprite = armour.Image;
    }

    public void SetHotkeyItem(EquippableItem item, int index)
    {
        if (item != null)
        {
            hotkeyItems[index] = item;
            HotkeyImages[index].sprite = item.Image;
        }
        else
        {
            hotkeyItems[index] = null;
            HotkeyImages[index].sprite = null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Create item lists
        for (int i = 0; i < 4; i++)
        {
            Weapons[i] = new EquippableItem(Enum.GetName(typeof(ItemColours), i) + " Sword", WeaponSprites[i], EquippableItem.ItemType.Weapon);
            Armours[i] = new EquippableItem(Enum.GetName(typeof(ItemColours), i) + " Armour", ArmourSprites[i], EquippableItem.ItemType.Armour);
        }

        // Remove hotkey mappings
        for (int i = 0; i < 10; i++)
        {
            SetHotkeyItem(null, i);
        }

        // Default equipped items
        SetEquippedWeapon(Weapons[(int)ItemColours.BLUE]);
        SetEquippedArmour(Armours[(int)ItemColours.RED]);

        SetHotkeyItem(Weapons[(int)ItemColours.PURPLE], 1);
        SetHotkeyItem(Weapons[(int)ItemColours.GREEN], 2);
        SetHotkeyItem(Armours[(int)ItemColours.BLUE], 3);
        SetHotkeyItem(Armours[(int)ItemColours.PURPLE], 4);

        isMenuOpen = false;
        OpenMenuButton.SetActive(true);
        MainMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Escape key closes and opens menu
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (isMenuOpen)
            {
                CloseMenu();
            }
            else
            {
                OpenMenu();
            }
        }

        // Hotkey bindings
        if (Keyboard.current.digit0Key.wasPressedThisFrame)
        {
            if (hotkeyItems[0].Type == EquippableItem.ItemType.Weapon)
            {
                SetEquippedWeapon(hotkeyItems[0]);
            }
            else if (hotkeyItems[0].Type == EquippableItem.ItemType.Armour)
            {
                SetEquippedArmour(hotkeyItems[0]);
            }
        }

        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            if (hotkeyItems[1].Type == EquippableItem.ItemType.Weapon)
            {
                SetEquippedWeapon(hotkeyItems[1]);
            }
            else if (hotkeyItems[1].Type == EquippableItem.ItemType.Armour)
            {
                SetEquippedArmour(hotkeyItems[1]);
            }
        }

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            if (hotkeyItems[2].Type == EquippableItem.ItemType.Weapon)
            {
                SetEquippedWeapon(hotkeyItems[2]);
            }
            else if (hotkeyItems[2].Type == EquippableItem.ItemType.Armour)
            {
                SetEquippedArmour(hotkeyItems[2]);
            }
        }

        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            if (hotkeyItems[3].Type == EquippableItem.ItemType.Weapon)
            {
                SetEquippedWeapon(hotkeyItems[3]);
            }
            else if (hotkeyItems[3].Type == EquippableItem.ItemType.Armour)
            {
                SetEquippedArmour(hotkeyItems[3]);
            }
        }

        if (Keyboard.current.digit4Key.wasPressedThisFrame)
        {
            if (hotkeyItems[4].Type == EquippableItem.ItemType.Weapon)
            {
                SetEquippedWeapon(hotkeyItems[4]);
            }
            else if (hotkeyItems[4].Type == EquippableItem.ItemType.Armour)
            {
                SetEquippedArmour(hotkeyItems[4]);
            }
        }

        if (Keyboard.current.digit5Key.wasPressedThisFrame)
        {
            if (hotkeyItems[5].Type == EquippableItem.ItemType.Weapon)
            {
                SetEquippedWeapon(hotkeyItems[5]);
            }
            else if (hotkeyItems[5].Type == EquippableItem.ItemType.Armour)
            {
                SetEquippedArmour(hotkeyItems[5]);
            }
        }

        if (Keyboard.current.digit6Key.wasPressedThisFrame)
        {
            if (hotkeyItems[6].Type == EquippableItem.ItemType.Weapon)
            {
                SetEquippedWeapon(hotkeyItems[6]);
            }
            else if (hotkeyItems[6].Type == EquippableItem.ItemType.Armour)
            {
                SetEquippedArmour(hotkeyItems[6]);
            }
        }

        if (Keyboard.current.digit7Key.wasPressedThisFrame)
        {
            if (hotkeyItems[7].Type == EquippableItem.ItemType.Weapon)
            {
                SetEquippedWeapon(hotkeyItems[7]);
            }
            else if (hotkeyItems[7].Type == EquippableItem.ItemType.Armour)
            {
                SetEquippedArmour(hotkeyItems[7]);
            }
        }

        if (Keyboard.current.digit8Key.wasPressedThisFrame)
        {
            if (hotkeyItems[8].Type == EquippableItem.ItemType.Weapon)
            {
                SetEquippedWeapon(hotkeyItems[8]);
            }
            else if (hotkeyItems[8].Type == EquippableItem.ItemType.Armour)
            {
                SetEquippedArmour(hotkeyItems[8]);
            }
        }

        if (Keyboard.current.digit9Key.wasPressedThisFrame)
        {
            if (hotkeyItems[9].Type == EquippableItem.ItemType.Weapon)
            {
                SetEquippedWeapon(hotkeyItems[9]);
            }
            else if (hotkeyItems[9].Type == EquippableItem.ItemType.Armour)
            {
                SetEquippedArmour(hotkeyItems[9]);
            }
        }
    }
}

using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

// Singleton
public class MenuController : MonoBehaviour
{
    public enum ItemColours
    {
        Blue = 0,
        Green = 1,
        Purple = 2,
        Red = 3
    }

    public enum MenuState
    {
        Closed,
        Main,
        Weapons,
        Armours,
        Settings
    }

    public static MenuController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<MenuController>();
            }

            return instance;
        }
    }

    public GameObject openMenuButton;
    
    public GameObject mainMenu;
    public GameObject weaponsMenu;
    public GameObject armoursMenu;
    public GameObject settingsMenu;
    public GameObject itemDetailsMenu;
    public GameObject messagesMenu;

    public Image equippedWeaponImage;
    public Image equippedArmourImage;

    public Sprite[] weaponSprites;
    public Sprite[] armourSprites;

    public Hotkey[] hotkeys;

    public EquippableItem[] weapons = new EquippableItem[4];
    public EquippableItem[] armours = new EquippableItem[4];

    public MessagesController messages;
    public ItemDetails itemDetails;
    public RowItem[] rowItems = new RowItem[8];

    private static MenuController instance;

    private MenuState state = MenuState.Main;

    private bool itemDetailsUpdated = true;
    private static bool itemDetailsFlag = true;

    private RowItem selectedRowItem = null;

    private EquippableItem equippedWeapon = null;
    private EquippableItem equippedArmour = null;

    private EquippableItem[] hotkeyItems = new EquippableItem[10];

    public void SetSelectedRowItem(RowItem rowItem)
    {
        if (rowItem == null)
        {
            selectedRowItem = rowItem;
            itemDetailsFlag = !itemDetailsFlag;
        }
        else if (rowItem.item != null)
        {
            if (selectedRowItem != null)
            {
                if (!rowItem.item.name.Equals(selectedRowItem.item.name))
                {
                    selectedRowItem.DeselectRowItem();
                }
            }

            selectedRowItem = rowItem;
            itemDetailsFlag = !itemDetailsFlag;
        }
    }

    public void EquipSelectedItem()
    {
        if (selectedRowItem != null && selectedRowItem.item != null)
        {
            if (selectedRowItem.item.type == EquippableItem.ItemType.Weapon)
            {
                SetEquippedWeapon(selectedRowItem.item);
            }
            else if (selectedRowItem.item.type == EquippableItem.ItemType.Armour)
            {
                SetEquippedArmour(selectedRowItem.item);
            }
        }
    }

    public void OpenMainMenu()
    {
        state = MenuState.Main;

        weaponsMenu.SetActive(false);
        armoursMenu.SetActive(false);
        settingsMenu.SetActive(false);

        openMenuButton.SetActive(false);
        mainMenu.SetActive(true);

        Debug.Log("Menu State " + state.ToString());
    }

    public void OpenWeaponsMenu()
    {
        state = MenuState.Weapons;

        mainMenu.SetActive(false);
        weaponsMenu.SetActive(true);

        Debug.Log("Menu State " + state.ToString());
    }

    public void OpenArmoursMenu()
    {
        state = MenuState.Armours;

        mainMenu.SetActive(false);
        armoursMenu.SetActive(true);

        Debug.Log("Menu State " + state.ToString());
    }

    public void OpenSettingsMenu()
    {
        state = MenuState.Settings;

        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);

        Debug.Log("Menu State " + state.ToString());
    }

    public void CloseSubmenu()
    {
        SetSelectedRowItem(null);

        weaponsMenu.SetActive(false);
        armoursMenu.SetActive(false);
        itemDetailsMenu.SetActive(false);
        settingsMenu.SetActive(false);

        OpenMainMenu();
    }

    public void CloseMainMenu()
    {
        state = MenuState.Closed;
        openMenuButton.SetActive(true);

        mainMenu.SetActive(false);

        Debug.Log("Menu State " + state.ToString());
    }

    public void SetEquippedWeapon(EquippableItem weapon)
    {
        equippedWeapon = weapon;
        equippedWeaponImage.sprite = weapon.sprite;
    }

    public void SetEquippedArmour(EquippableItem armour)
    {
        equippedArmour = armour;
        equippedArmourImage.sprite = armour.sprite;
    }

    public void SetHotkeyItem(EquippableItem item, int index)
    {
        if (item != null)
        {
            hotkeyItems[index] = item;
            hotkeys[index].SetItem(item);

            // Remove item from other hotkeys
            for (int i = 0; i < 10; i++)
            {
                if (i != index)
                {
                    if (hotkeyItems[i] != null && hotkeyItems[i].name.Equals(item.name))
                    // Recursion!
                    SetHotkeyItem(null, i);
                }
            }
        }
        else
        {
            hotkeyItems[index] = null;
            hotkeys[index].SetItem(null);
        }
    }

    public void HideMessage()
    {
        messagesMenu.SetActive(false);
    }

    public void SaveGame()
    {
        ShowMessage("Saved the game!");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ActivateHotkey(int index)
    {
        if (state == MenuState.Closed)
        {
            EquipHotkeyItem(index);
        }
        else
        {
            HotkeySelectedItem(index);
        }
    }

    void Start()
    {
        ConfigureTestData();
        CloseSubmenu();
        CloseMainMenu();
        HideMessage();
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (messagesMenu.activeInHierarchy || messagesMenu.activeSelf)
            {
                HideMessage();
            }
            else if (state == MenuState.Closed)
            {
                OpenMainMenu();
            }
            else
            {
                if (state == MenuState.Main)
                {
                    CloseMainMenu();
                }
                else
                {
                    CloseSubmenu();
                }
            }
        }
        else if (Keyboard.current.digit0Key.wasPressedThisFrame)
        {
            ActivateHotkey(0);
        }
        else if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            ActivateHotkey(1);
        }
        else if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            ActivateHotkey(2);
        }
        else if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            ActivateHotkey(3);
        }
        else if (Keyboard.current.digit4Key.wasPressedThisFrame)
        {
            ActivateHotkey(4);
        }
        else if (Keyboard.current.digit5Key.wasPressedThisFrame)
        {
            ActivateHotkey(5);
        }
        else if (Keyboard.current.digit6Key.wasPressedThisFrame)
        {
            ActivateHotkey(6);
        }
        else if (Keyboard.current.digit7Key.wasPressedThisFrame)
        {
            ActivateHotkey(7);
        }
        else if (Keyboard.current.digit8Key.wasPressedThisFrame)
        {
            ActivateHotkey(8);
        }
        else if (Keyboard.current.digit9Key.wasPressedThisFrame)
        {
            ActivateHotkey(9);
        }

        // If selected item has changed, update item details menu
        if (itemDetailsUpdated != itemDetailsFlag)
        {
            UpdateItemDetails();
        }
    }

    void UpdateItemDetails()
    {
        if (selectedRowItem == null || selectedRowItem.item == null)
        {
            itemDetailsMenu.SetActive(false);
        }
        else
        {
            itemDetails.SetItemDetails(selectedRowItem.item);
            itemDetailsMenu.SetActive(true);
        }

        itemDetailsUpdated = itemDetailsFlag;
    }

    void EquipHotkeyItem(int index)
    {
        if (hotkeyItems[index] != null)
        {
            if (hotkeyItems[index].type == EquippableItem.ItemType.Weapon)
            {
                SetEquippedWeapon(hotkeyItems[index]);
            }
            else if (hotkeyItems[index].type == EquippableItem.ItemType.Armour)
            {
                SetEquippedArmour(hotkeyItems[index]);
            }
        }
    }

    void HotkeySelectedItem(int index)
    {
        if (selectedRowItem != null && selectedRowItem.item != null)
        {
            SetHotkeyItem(selectedRowItem.item, index);
        }
    }

    void ShowMessage(string message)
    {
        messages.UpdateMessage(message);
        messagesMenu.SetActive(true);
    }

    void ConfigureTestData()
    {
        // Create item lists
        for (int i = 0; i < 4; i++)
        {
            weapons[i] = new EquippableItem(Enum.GetName(typeof(ItemColours), i) + " Sword", weaponSprites[i], EquippableItem.ItemType.Weapon);
            armours[i] = new EquippableItem(Enum.GetName(typeof(ItemColours), i) + " Armour", armourSprites[i], EquippableItem.ItemType.Armour);
        }

        // Remove hotkey mappings
        for (int i = 0; i < 10; i++)
        {
            SetHotkeyItem(null, i);
        }

        // Default equipped items
        SetEquippedWeapon(weapons[(int)ItemColours.Blue]);
        SetEquippedArmour(armours[(int)ItemColours.Red]);

        SetHotkeyItem(weapons[(int)ItemColours.Purple], 1);
        SetHotkeyItem(weapons[(int)ItemColours.Green], 2);
        SetHotkeyItem(armours[(int)ItemColours.Blue], 3);
        SetHotkeyItem(armours[(int)ItemColours.Purple], 4);

        // Default row items
        for (int i = 0; i < 4; i++)
        {
            rowItems[i].SetItem(weapons[i]);
            rowItems[i + 4].SetItem(armours[i]);
        }
    }
}

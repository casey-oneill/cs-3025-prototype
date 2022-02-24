using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippableItem
{
    public enum ItemType
    {
        Weapon,
        Armour
    }

    public string name;
    public Sprite sprite;
    public ItemType type;

    public EquippableItem(string name, Sprite image, ItemType type)
    {
        this.name = name;
        this.sprite = image;
        this.type = type;
    }
}

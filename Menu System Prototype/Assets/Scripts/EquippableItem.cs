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

    public string Name;
    public Sprite Image;
    public ItemType Type;

    public EquippableItem(string name, Sprite image, ItemType type)
    {
        this.Name = name;
        this.Image = image;
        this.Type = type;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hotkey : MonoBehaviour
{

    public Image image;

    private EquippableItem item;

    public void SetItem(EquippableItem item)
    {
        this.item = item;

        if (item == null)
        {
            image.sprite = null;
        }
        else
        {
            image.sprite = item.sprite;
        }
    }
}

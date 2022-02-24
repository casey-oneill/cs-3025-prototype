using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetails : MonoBehaviour
{

    public Image image;
    public Text headerText;
    public Text detailsText;

    public void SetItemDetails(EquippableItem item)
    {
        image.sprite = item.sprite;
        headerText.text = item.name;

        if (item.type == EquippableItem.ItemType.Weapon)
        {
            detailsText.text = "A sword to swing at enemies!";
        }
        else if (item.type == EquippableItem.ItemType.Armour)
        {
            detailsText.text = "Armour to reduce damage taken from enemies.";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RowItem : MonoBehaviour
{

    public EquippableItem item;
    public Image boxImage;
    public Image image;

    public Sprite defaultBoxImage;
    public Sprite selectedBoxImage;

    private bool isSelected;

    public void SetItem(EquippableItem item)
    {
        this.item = item;
        image.sprite = item.sprite;
    }

    private void Start()
    {
        isSelected = false;
        UpdateBoxImage();
    }

    void UpdateBoxImage()
    {
        if (isSelected)
        {
            boxImage.sprite = selectedBoxImage;
        }
        else
        {
            boxImage.sprite = defaultBoxImage;
        }
    }

    public void ClickRowItem()
    {
        if (item != null)
        {
            isSelected = !isSelected;
            UpdateBoxImage();

            if (isSelected)
            {
                MenuController.SetSelectedRowItem(this);
            }
            else
            {
                MenuController.SetSelectedRowItem(null);
            }
        }
    }

    public void DeselectRowItem()
    {
        isSelected = false;
        UpdateBoxImage();
    }

    public void HoverOnRowItem()
    {
        if (item != null)
        {
            boxImage.sprite = selectedBoxImage;
        }
    }

    public void HoverOffRowItem()
    {
        UpdateBoxImage();
    }
}

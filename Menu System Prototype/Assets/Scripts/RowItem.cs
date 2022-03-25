using UnityEngine;
using UnityEngine.UI;

public class RowItem : MonoBehaviour
{

    public EquippableItem item;
    public Image boxImage;
    public Image image;

    public Sprite defaultBoxImage;
    public Sprite selectedBoxImage;

    private MenuController menuController;
    private bool isSelected;

    public void SetItem(EquippableItem item)
    {
        this.item = item;
        image.sprite = item.sprite;
    }

    private void Start()
    {
        menuController = MenuController.Instance;
        if (menuController == null)
        {
            Debug.LogError("[RowItem] Failed to find MenuController instance.");
        }

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
                menuController.SetSelectedRowItem(this);
            }
            else
            {
                menuController.SetSelectedRowItem(null);
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

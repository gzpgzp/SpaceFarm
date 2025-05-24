using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    public Item slotItem;
    
    public Image slotImage;

    public TMP_Text slotNum;
    public TMP_Text slotPrice;
    
    public GameObject itemInSolt;
    public GameObject priceButton;

    public bool isActive = false;

    public void SetupItem(Item item, int itemHeld)
    {
        if (item == null)
        {
            isActive = false;
            itemInSolt.SetActive(false);
            priceButton.SetActive(false);
        }
        else
        {
            isActive = true;
            slotItem = item;
            slotImage.sprite = slotItem.itemImage;
            slotNum.text = itemHeld.ToString();
            slotPrice.text = slotItem.price.ToString();
            itemInSolt.SetActive(true);
            priceButton.SetActive(true);
        }
    }

    public void BuyItem()
    {
        ShopInventoryManager.showMessage(slotItem);
    }

    public void TakeItemToBag()
    {
        
    }

}

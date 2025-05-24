using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item slotItem;
    
    public Image slotImage;

    public TMP_Text slotNum;
    
    public GameObject itemInSolt;

    public bool isActive = false;

    public void SetupItem(Item item, int itemHeld)
    {
        if (item == null)
        {
            isActive = false;
            itemInSolt.SetActive(false);
        }
        else
        {
            isActive = true;
            slotItem = item;
            slotImage.sprite = slotItem.itemImage;
            slotNum.text = itemHeld.ToString();
            itemInSolt.SetActive(true);
        }
    }

}

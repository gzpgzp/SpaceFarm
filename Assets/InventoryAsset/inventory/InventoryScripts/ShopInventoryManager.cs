using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Script.Models;

public class ShopInventoryManager : MonoBehaviour
{
    static ShopInventoryManager Instance;
    
    public GameObject soltGrid;

    public GameObject emptySolt;
    
    public GameObject buyMessageBox;
    
    public List<GameObject> slots = new List<GameObject>();
    
    private void Awake()
    {
        if (Instance != null)
        { 
            Destroy(this);
        }

        Instance = this;
        
        buyMessageBox.SetActive(false);
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public static void RefreshItemSlot(List<ItemDictionaryModel> itemList)
    {
        Instance.slots = new List<GameObject>();
        CreateSlot();
        
        for (int i = 0; i < itemList.Count; i++)
        {
            Item slotItem = itemList[i].item;
            for (int j = 0; j < Instance.slots.Count; j++)
            {
                if (Instance.slots[j].GetComponent<ShopSlot>().isActive) 
                {
                    continue;
                }

                int h = itemList[i].count;
                if (h > 999) 
                {
                    while (h > 999) 
                    {
                        Instance.slots[j].GetComponent<ShopSlot>().SetupItem(slotItem, 999);
                        h -= 999;
                        j++;
                    }
                }
                Instance.slots[j].GetComponent<ShopSlot>().SetupItem(slotItem, h);
                break;
            }
        }

    }
    
    public static void CreateSlot()
    {
        for (int i = 0; i < Instance.soltGrid.transform.childCount; i++)
        {
            Destroy(Instance.soltGrid.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < 18; i++)
        {
            Instance.slots.Add(Instantiate(Instance.emptySolt, Instance.soltGrid.transform.position, quaternion.identity));
            Instance.slots[i].transform.SetParent(Instance.soltGrid.transform,false);
            Instance.slots[i].GetComponent<ShopSlot>().SetupItem(null, 0);
        }
    }

    public static void showMessage(Item slotItem)
    {
        Instance.buyMessageBox.GetComponent<BuyItemConfirm>().buyItem = slotItem;
        Instance.buyMessageBox.GetComponent<BuyItemConfirm>().contentText.text = slotItem.itemName;
        Instance.buyMessageBox.GetComponent<BuyItemConfirm>().countSlider.value = 1;
        Instance.buyMessageBox.SetActive(true);
    }
}

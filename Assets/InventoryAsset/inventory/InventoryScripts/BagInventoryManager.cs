using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Mime;
using DG.Tweening;
using Script.Models;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class BagInventoryManager : MonoBehaviour
{
    static BagInventoryManager Instance;
    
    /// <summary>
    /// 物品网格
    /// </summary>
    public GameObject slotGrid;

    /// <summary>
    /// 空格
    /// </summary>
    public GameObject emptySlot;
    
    public List<GameObject> slots = new List<GameObject>();

    public Inventory myBag;
    
    private void Awake()
    {
        if (Instance != null)
        { 
            Destroy(this);
        }

        Instance = this;
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
                if (Instance.slots[j].GetComponent<Slot>().isActive) 
                {
                    continue;
                }

                int h = itemList[i].count;
                if (h > 999) 
                {
                    while (h > 999) 
                    {
                        Instance.slots[j].GetComponent<Slot>().SetupItem(slotItem, 999);
                        h -= 999;
                        j++;
                    }
                }
                Instance.slots[j].GetComponent<Slot>().SetupItem(slotItem, h);
                break;
            }
        }

    }
    
    public static void CreateSlot()
    {
        for (int i = 0; i < Instance.slotGrid.transform.childCount; i++)
        {
            Destroy(Instance.slotGrid.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < 24; i++)
        {
            Instance.slots.Add(Instantiate(Instance.emptySlot, Instance.slotGrid.transform.position, quaternion.identity));
            Instance.slots[i].transform.SetParent(Instance.slotGrid.transform,false);
            Instance.slots[i].GetComponent<Slot>().SetupItem(null, 0);
        }
    }
}

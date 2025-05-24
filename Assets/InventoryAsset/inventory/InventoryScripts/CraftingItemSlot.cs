using System.Collections;
using System.Collections.Generic;
using Script.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Unity.Mathematics;


public class CraftingItemSlot : MonoBehaviour
{
    /// <summary>
    /// 玩家背包
    /// </summary>
    public Inventory PlayerBag;
    
    public Item slotItem;

    public GameObject slotImageGo;
    public GameObject slotImageReadyGO;
    public Image slotImage;
    public Image slotImageReady;
    public GameObject ClearButton;
    
    private bool isExistItem = false;

    public GameObject emptyEntry;
    public GameObject entriesGrid;
    private List<GameObject> entryList = new List<GameObject>();
    private void Start()
    {
        CreateSlot();
        slotImageGo.SetActive(false);
        slotItem = ScriptableObject.CreateInstance<Item>();
    }
    
    public void SetItemReady(Item si)
    {
        if (si.type != ItemType.Seed)
            return;
        
        slotImageReadyGO.SetActive(true);
        slotImageReady.sprite = si.itemImage;
    }
    
    public bool SetSlotItem(Item si)
    {
        if (si.type != ItemType.Seed)
            return false;
        if (isExistItem)
        {
            PlayerBag.addItemToBag(slotItem, 1);
        }

        ClearButton.SetActive(true);

        slotImageGo.SetActive(true);
        slotImageReadyGO.SetActive(false);
        slotImage.sprite = si.itemImage;
        slotItem = si;
        isExistItem = true;
        return true;
    }
    
    public void SetItemLeave()
    {
        slotImageReadyGO.SetActive(false);
        slotImageReady.sprite = null;
    }
    
    public void ItemClear()
    {
        if (!isExistItem)
            return;
        
        ClearButton.SetActive(false);
        slotImageGo.SetActive(false);
        PlayerBag.addItemToBag(slotItem, 1);
        slotImage.sprite = null;
        slotItem = ScriptableObject.CreateInstance<Item>();
        isExistItem = false;
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    public void RefreshItemSlot(List<Entry> entries)
    {
        entryList = new List<GameObject>();
        CreateSlot();
        
        for (int i = 0; i < entries.Count; i++)
        {
            entryList[i].GetComponent<EntryItem>().SetEntryItem(entries[i]);
        }

    }
    
    public void CreateSlot()
    {
        for (int i = 0; i < entriesGrid.transform.childCount; i++)
        {
            Destroy(entriesGrid.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < 4; i++)
        {
            entryList.Add(Instantiate(emptyEntry, entriesGrid.transform.position, quaternion.identity));
            entryList[i].transform.SetParent(entriesGrid.transform,false);
            entryList[i].GetComponent<EntryItem>().SetEntryItem(null);
        }
    }
}

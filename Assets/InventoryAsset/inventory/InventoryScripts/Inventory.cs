using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Script.Models;
using UnityEngine;
using UnityEngine.Serialization;
using Newtonsoft.Json;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/New Inventory")]
public class Inventory : ScriptableObject
{
    public Dictionary<string,ItemDictionaryModel> ItemDictionary = new Dictionary<string, ItemDictionaryModel>();

    public int coin;
    public int diamond;
    
    public void addItemToBag(Item item,int count)
    {
        if (!this.ItemDictionary.ContainsKey(item.itemId))
        {
            this.ItemDictionary.Add(item.itemId, new ItemDictionaryModel()
            {
                item = item,
                count = count
            });
        }
        else
        {
            this.ItemDictionary[item.itemId].count += count;
        }

        if (this.ItemDictionary[item.itemId].count == 0)
        {
            this.ItemDictionary.Remove(item.itemId);
        }
        BagInventoryManager.RefreshItemSlot(ItemDictionary.Values.ToList());
    }

    public void addItemToShop(Item item, int count)
    {
        if (!this.ItemDictionary.ContainsKey(item.itemId))
        {
            this.ItemDictionary.Add(item.itemId, new ItemDictionaryModel()
            {
                item = item,
                count = count
            });
        }
        else
        {
            this.ItemDictionary[item.itemId].count += count;
        }
        ShopInventoryManager.RefreshItemSlot(ItemDictionary.Values.ToList());
    }

    public void clearDictionary()
    {
        this.ItemDictionary.Clear();
    }
}


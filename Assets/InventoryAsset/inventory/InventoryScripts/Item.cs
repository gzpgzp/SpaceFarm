using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Script.Models;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/New Item")]
public class Item : ScriptableObject
{
    /// <summary>
    /// 物品唯一标识码
    /// </summary>
    public string itemId;
    
    /// <summary>
    /// 物品名称
    /// </summary>
    public string itemName;
    
    /// <summary>
    /// 物品图片
    /// </summary>
    public Sprite itemImage;
    
    /// <summary>
    /// 物品描述
    /// </summary>
    [TextArea]
    public string itemInfo;
    
    /// <summary>
    /// 物品单价
    /// </summary>
    public int price;

    /// <summary>
    /// 物品类型
    /// </summary>
    public ItemType type;
}

using System.Collections;
using System.Collections.Generic;
using Script.Models;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class EntryItem : MonoBehaviour
{
    public Entry EntryOfItem;

    public TMP_Text entryInfo;

    public Image lockImage;

    public void SetEntryItem(Entry entry)
    {
        if (entry == null)
        {
            lockImage.color = new Color(255, 255, 255, 100);
            entryInfo.text = "Empty";
            entryInfo.color = Color.white;
            return;
        }
        
        lockImage.color = new Color(255, 255, 255, 255);
        EntryOfItem = entry;
        entryInfo.text = entry.Name;
        Color rankColor = entry.EntryRankEnum switch
        {
            RankEnum.R => Color.green,
            RankEnum.SR => Color.blue,
            RankEnum.SSR => Color.magenta,
            RankEnum.UR => new Color32(254, 206, 87, 255),
            _ => Color.white
        };
        entryInfo.color = rankColor;
    }
}

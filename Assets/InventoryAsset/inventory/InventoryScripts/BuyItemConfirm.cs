using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuyItemConfirm : MonoBehaviour
{
    /// <summary>
    /// 购买的物品
    /// </summary>
    public Item buyItem;
    
    /// <summary>
    /// 玩家背包
    /// </summary>
    public Inventory PlayerBag;
    
    public Slider countSlider;
    public TMP_Text contentText;
    
    public TMP_Text countText;
    
    public TMP_Text CoinCountText;

    private void Update()
    {
        countText.text = countSlider.value.ToString(CultureInfo.InvariantCulture);
        CoinCountText.text = (buyItem.price * countSlider.value).ToString(CultureInfo.InvariantCulture);
    }

    public void ConfirmButtonClick()
    {
        int count = int.Parse(countSlider.value.ToString().Split('.')[0]);
        int charge = buyItem.price * count;

        if (charge > PlayerBag.coin)
        {
            ToastPanel.instance.ShowMessage("You do not have enough money to buy this item.");
            return;
        }

        CoinBox.CoinSet(PlayerBag.coin, PlayerBag.coin - charge);
        PlayerBag.coin -= charge;
        PlayerBag.addItemToBag(buyItem, count);
        this.gameObject.SetActive(false);
        
        //ToastPanel.instance.ShowMessage("Buy successful!");
    }

    public void CancelButtonClick()
    {
        this.gameObject.SetActive(false);
    }

    public void Add1Item()
    {
        countSlider.value++;
    }

    public void Sub1Item()
    {
        countSlider.value--;
    }
}

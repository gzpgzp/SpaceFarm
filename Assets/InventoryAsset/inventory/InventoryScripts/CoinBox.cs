using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CoinBox : MonoBehaviour
{
    private static CoinBox Instance;
        
    /// <summary>
    /// 金币数量Text
    /// </summary>
    public TMP_Text CoinCountText;
    
    /// <summary>
    /// 钻石数量Text
    /// </summary>
    public TMP_Text DiamondCountText;

    private void Awake()
    {
        if (Instance != null)
        { 
            Destroy(this);
        }

        Instance = this;
    }
    
    public static void CoinSet(long startCoin, long endCoin, float duration = 1)
    {

        Tweener t = DOTween.To(() => startCoin, (value) =>
        {
            Instance.CoinCountText.text = $"{value:N0}";
        }, endCoin, duration).SetEase(Ease.Linear);
    }

    public static void DiamondSet(long startCoin, long endCoin, float duration = 1)
    {

        Tweener t = DOTween.To(() => startCoin, (value) =>
        {
            Instance.DiamondCountText.text = $"{value:N0}";
        }, endCoin, duration).SetEase(Ease.Linear);
    }

}

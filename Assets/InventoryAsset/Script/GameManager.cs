using System;
using System.Collections.Generic;
using  Script.FileManage;
using UnityEngine;
using UnityEngine.Serialization;
using DG.Tweening;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject myBag;
    public Inventory PlayerBag;
    public bool bagIsOpen = false;

    public GameObject myShop;
    public Inventory Shop;
    public bool shopIsOpen = false;

    public Item itemTest;
    public Item itemTest2;
    public Item itemTest3;
    public Item itemTest4;
    
    public TMP_Text openButtonText;

    private void Awake()
    {
        List<testCSV> list = new List<testCSV>();
        list = CsvReader.CSVToList<testCSV>("E:\\unity\\素材\\test\\test.csv");
    }

    private void Start()
    {
        myShop.SetActive(true);
        CoinBox.CoinSet(99999999,PlayerBag.coin);
        CoinBox.DiamondSet(99999999,PlayerBag.diamond);
        BagInventoryManager.CreateSlot();
        ShopInventoryManager.CreateSlot();
        Shop.addItemToShop(itemTest, 99);
        Shop.addItemToShop(itemTest2, 99);
        Shop.addItemToShop(itemTest3, 99);
        Shop.addItemToShop(itemTest4, 99);
        myShop.SetActive(shopIsOpen);
    }

    private void Update()
    {
        OpenBag();
        OpenShop();
    }

    public void OpenBag()
    {
        if (Input.GetKeyDown((KeyCode.Tab)) && !shopIsOpen)
        {
            BagShow();
        }        
    }

    public void BagShow()
    {
        bagIsOpen = !bagIsOpen;
        // PlayerBag.addItem(itemTest);
        if (bagIsOpen)
        {
            myBag.transform.DOLocalMove(new Vector3(-660, myBag.transform.localPosition.y), 0.5f);
            openButtonText.text = "Close";
        }
        else
        {
            myBag.transform.DOLocalMove(new Vector3(-1260, myBag.transform.localPosition.y), 0.5f);
            openButtonText.text = "Open";
        }
    }
    
    void OpenShop()
    {
        if (Input.GetKeyDown((KeyCode.B)))
        {
            ShopShow();
        }        
    }

    public void ShopShow()
    {
        shopIsOpen = !shopIsOpen;
        myShop.SetActive(shopIsOpen);
    }

    [Serializable]
    public class testCSV
    {
        public string test1 { get; set; }
        public string test2 { get; set; }
        public string test3 { get; set; }
    }
    
}

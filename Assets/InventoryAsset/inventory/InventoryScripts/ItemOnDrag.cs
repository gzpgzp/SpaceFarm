using System;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

namespace inventory.InventoryScripts
{
    public class ItemOnDrag : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
    {
        public Item item;
        public Inventory PlayerBag;
        
        public Transform originParent;

        public Image itemImage;

        private Image draggedImage;
        private Canvas draggedCanvas;
        
        private GameObject go;
        
        private CanvasGroup canvasGroup;
        private CanvasGroup draggedCanvasGroup;

        private void Start()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            originParent = transform.parent;
            Slot slot = originParent.GetComponent<Slot>();
            item = slot.slotItem;
            if (slot.isActive)
            {
                canvasGroup.alpha = 0.5f;
                canvasGroup.blocksRaycasts = false;
            
                go = new GameObject("DraggedItem");
                draggedImage = go.AddComponent<Image>();
                draggedImage.sprite = itemImage.sprite;
                draggedImage.SetNativeSize();
                draggedCanvas = go.AddComponent<Canvas>();
                draggedCanvas.overrideSorting = true;
                draggedCanvas.sortingOrder = 999;
                go.transform.SetParent(transform.parent.parent.parent.parent);
                
                draggedCanvasGroup = go.AddComponent<CanvasGroup>();
                draggedCanvasGroup.blocksRaycasts = false;
                GetComponent<CanvasGroup>().blocksRaycasts = false;
            }

        }

        private GameObject itemOnRayCastlast = null; 
        public void OnDrag(PointerEventData eventData)
        {
            go.transform.position = eventData.position;
            
            GameObject itemOnRayCast = eventData.pointerCurrentRaycast.gameObject;
            
            if (itemOnRayCast != itemOnRayCastlast)
            {
                if (itemOnRayCast != null)
                {
                    if (itemOnRayCast.CompareTag("CraftingItem"))
                    {
                        itemOnRayCast.GetComponent<CraftingItemSlot>().SetItemReady(item);
                    }
                }

                if (itemOnRayCastlast != null)
                {
                    if (itemOnRayCastlast.CompareTag("CraftingItem"))
                    {
                        itemOnRayCastlast.GetComponent<CraftingItemSlot>().SetItemLeave();
                    }
                }

            }

            itemOnRayCastlast = itemOnRayCast;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            GameObject itemOnRayCast = eventData.pointerCurrentRaycast.gameObject;
            if (itemOnRayCast != null)
            {
                Transform itemTransOnRayCast = eventData.pointerCurrentRaycast.gameObject.transform;
                if (itemOnRayCast.CompareTag("CraftingItem"))
                {
                    if (itemOnRayCast.GetComponent<CraftingItemSlot>().SetSlotItem(item))
                    {
                        PlayerBag.addItemToBag(item,-1);
                        canvasGroup.alpha = 1f;
                        canvasGroup.blocksRaycasts = true;
                        Destroy(go);
                        return;
                    }
                }
            }
            
            go.transform.position = eventData.position;
            
            // 计算当前位置和原始位置的距离
            float distance = Vector3.Distance(go.transform.position, originParent.position);
            // 根据距离动态调整动画时长，这里设定最短时长为 0.1 秒，最长为 0.5 秒
            float moveDuration = Mathf.Clamp(distance / 1000, 0.01f, 0.3f);
            go.transform.DOMove(originParent.position, moveDuration).OnComplete(() =>
            {
                canvasGroup.alpha = 1f;
                canvasGroup.blocksRaycasts = true;
                Destroy(go);
            });
        }

    }
}

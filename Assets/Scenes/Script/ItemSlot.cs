using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour,
    IPointerClickHandler,
    IBeginDragHandler,
    IDragHandler,
    IEndDragHandler

{
    public Image iconImage; //슬롯안의 아이콘 이미지
    public TMP_Text countText;  //우측상단의 개수 (X개)


    [HideInInspector] public int slotIndex; //인벤토리 슬롯 번호
    private Inventory inventory;

    private GameObject dragIcon;
    private Transform canvasTransform;
    public Canvas parentCanvas;

    public void SetInventory(Inventory inv)
    {
        inventory = inv;
        
        if(parentCanvas == null)
        {
            parentCanvas = inv.GetComponentInParent<Canvas>();
        }

        canvasTransform = parentCanvas != null ? parentCanvas.transform : null;
    }

    public void Set(ItemData item, int count)
    {
       
        if (item != null)
        {
            iconImage.sprite = item.itemIcon;
            iconImage.enabled = true;

            countText.text = (count > 1) ? $"x{count}" : "";

        }

        else
        {
            //슬롯이 비어있으면 초기화
            iconImage.sprite = null;
            iconImage.enabled = false;
            countText.text = "";
        }
    }

   //클릭으로 인벤토리 아이템 사용
    public void OnPointerClick(PointerEventData eventData)
    {
        inventory.UseItem(slotIndex);
    }
   
    // 드래그 시작
    public void OnBeginDrag(PointerEventData eventData)
    {
        var slot = inventory.slots[slotIndex];
        if (slot.item != null) return;

        dragIcon = new GameObject("DragIcon");
        dragIcon.transform.SetParent(canvasTransform);
        dragIcon.transform.SetAsLastSibling();

        var img = dragIcon.AddComponent<Image>();
        img.sprite = iconImage.sprite;
        img.raycastTarget = false;
        img.SetNativeSize();

    }

    // 드래그 중
    public void OnDrag(PointerEventData eventData) 
    {
        if (dragIcon != null)
        {
            dragIcon.transform.position = Input.mousePosition;
        }

    }

    //드래그 종료 - 퀵슬롯 등록
    public void OnEndDrag(PointerEventData eventData)
    { 
        if(dragIcon != null)
        {
            Destroy(dragIcon);
        }

        if (eventData.pointerEnter != null)
        {
            var quickslot = eventData.pointerEnter.GetComponentInParent<QuickSlot>();
            if (quickslot != null)
            {
                var slot = inventory.slots[slotIndex];
                if (slot.item != null)
                {
                    quickslot.SetItem(slot.item);
                    Debug.Log($"{slot.item.itemName} 을(를) 퀵슬롯에 등록하였습니다.");
                }

            }
        
        }
    }

}

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
    public Image iconImage; //���Ծ��� ������ �̹���
    public TMP_Text countText;  //��������� ���� (X��)


    [HideInInspector] public int slotIndex; //�κ��丮 ���� ��ȣ
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
            //������ ��������� �ʱ�ȭ
            iconImage.sprite = null;
            iconImage.enabled = false;
            countText.text = "";
        }
    }

   //Ŭ������ �κ��丮 ������ ���
    public void OnPointerClick(PointerEventData eventData)
    {
        inventory.UseItem(slotIndex);
    }
   
    // �巡�� ����
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

    // �巡�� ��
    public void OnDrag(PointerEventData eventData) 
    {
        if (dragIcon != null)
        {
            dragIcon.transform.position = Input.mousePosition;
        }

    }

    //�巡�� ���� - ������ ���
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
                    Debug.Log($"{slot.item.itemName} ��(��) �����Կ� ����Ͽ����ϴ�.");
                }

            }
        
        }
    }

}

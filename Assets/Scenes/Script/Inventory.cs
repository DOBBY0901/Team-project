using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class Inventory : MonoBehaviour
{
    public InventorySlot[] slots = new InventorySlot[20]; //인벤토리 20슬롯

    public ItemSlot[] uiSlots; //ui 슬롯 연결

     public void Awake()
    {
        //초기화 - 가방 비우기
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = new InventorySlot();
        }
        UpdateUI();
    }

    public bool AddItem(ItemData newitem, int amount)
    {
        //아이템 획득시 같은 아이템이 있는지 확인
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == newitem)
            {
                slots[i].count += amount;
                Debug.Log($"{newitem.itemName}을(를) {amount}개 획득했습니다.");
                Debug.Log($"{newitem.itemName}을(를) {slots[i].count}개 보유중입니다.");

                UpdateUI();
                return true;
            }

        }

        //새로운 아이템 획득시 비어있는 슬롯에 추가
        for (int i = 0; i < slots.Length; i++)
        {
       
            if(slots[i].IsEmpty)
            {
                slots[i].item = newitem;
                slots[i].count = amount;
                Debug.Log($"{newitem.itemName}을(를) 획득했습니다.");
                
                UpdateUI();
                return true;
            }
        }

        //인벤토리가 꽉찼는데 새로운 아이템을 획득했을 시

        Debug.Log($"인벤토리가 가득 찼습니다.");
        return false;
    }

    public void UpdateUI() //UI 새로고침
    {
        for(int i = 0;i < slots.Length;i++)
        {
            if(i < uiSlots.Length)
            {
                uiSlots[i].Set(slots[i].item, slots[i].count);
            }
        }
    }

}

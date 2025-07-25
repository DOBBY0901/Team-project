using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class Inventory : MonoBehaviour
{
    public InventorySlot[] slots = new InventorySlot[20]; //�κ��丮 20����

    public ItemSlot[] uiSlots; //ui ���� ����

     public void Awake()
    {
        //�ʱ�ȭ - ���� ����
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = new InventorySlot();
        }
        UpdateUI();
    }

    public bool AddItem(ItemData newitem, int amount)
    {
        //������ ȹ��� ���� �������� �ִ��� Ȯ��
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == newitem)
            {
                slots[i].count += amount;
                Debug.Log($"{newitem.itemName}��(��) {amount}�� ȹ���߽��ϴ�.");
                Debug.Log($"{newitem.itemName}��(��) {slots[i].count}�� �������Դϴ�.");

                UpdateUI();
                return true;
            }

        }

        //���ο� ������ ȹ��� ����ִ� ���Կ� �߰�
        for (int i = 0; i < slots.Length; i++)
        {
       
            if(slots[i].IsEmpty)
            {
                slots[i].item = newitem;
                slots[i].count = amount;
                Debug.Log($"{newitem.itemName}��(��) ȹ���߽��ϴ�.");
                
                UpdateUI();
                return true;
            }
        }

        //�κ��丮�� ��á�µ� ���ο� �������� ȹ������ ��

        Debug.Log($"�κ��丮�� ���� á���ϴ�.");
        return false;
    }

    public void UpdateUI() //UI ���ΰ�ħ
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

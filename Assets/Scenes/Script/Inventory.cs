using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
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

    public int maxStack = 99; //�� ���� �κ��丮 ���Կ� ���� �� �ִ� �ִ� ����
    public bool AddItem(ItemData newitem, int amount)
    {
        int remainingitem = amount; // �־���� ������ ����

        //������ ȹ��� ���� �������� �ִ��� Ȯ�� , �����ҽ� �����߰�(99������)
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == newitem && slots[i].count < maxStack)
            {
                int space = maxStack - slots[i].count; //�ش� ���Կ� ��������
                int toAdd = Mathf.Min(space, remainingitem); //���� �� �ִ� ��ŭ�� �ֱ�

                slots[i].count += toAdd;
                remainingitem -= toAdd;

                Debug.Log($"{newitem.itemName}��(��) {toAdd}�� ȹ���߽��ϴ�.");
                Debug.Log($"{newitem.itemName}��(��) {slots[i].count}�� �������Դϴ�.");

               if(remainingitem <= 0)
                {
                    UpdateUI();
                    return true;
                }
               
            }

        }

        //���ο� ������ ȹ��� ����ִ� ���Կ� �߰�
        for (int i = 0; i < slots.Length; i++)
        {
       
            if(slots[i].IsEmpty && remainingitem > 0)
            {
                int toAdd = Mathf.Min(maxStack, remainingitem);
                slots[i].item = newitem;
                slots[i].count = toAdd;
                remainingitem -= toAdd;

                Debug.Log($"{newitem.itemName}��(��) ȹ���߽��ϴ�.");
                
                if(remainingitem <= 0)
                {
                    UpdateUI();
                    return true;
                }
                
            }
        }

        //�κ��丮�� ��á�µ� ���ο� �������� ȹ������ ��
        if(remainingitem > 0)
        {
            Debug.Log($"�κ��丮�� ���� á���ϴ�.");
            return false;

        }

        UpdateUI();
        return remainingitem == 0;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class InventorySlot
{
    public ItemData item; //������ ����
    public int count; //������ ����
    public bool IsEmpty => item == null; //����ִ� �������� Ȯ��
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class InventorySlot
{
    public ItemData item; //아이템 종류
    public int count; //아이템 개수
    public bool IsEmpty => item == null; //비어있는 슬롯인지 확인
   
}

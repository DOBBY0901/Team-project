using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/BasicItem")]
public class ItemData : ScriptableObject
{
    public string itemName; //아이템 이름
    public Sprite itemIcon; //아이템 아이콘
    public ItemType itemtype; //아이템 종류
    public int maxStack = 99; //아이템 최대 스택 수
}

public enum ItemType
{ 
    Heal,           //체력회복 아이템
    Placeable,      //설치형 아이템
    Consumable      //소모품 아이템

}
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/BasicItem")]
public class ItemData : ScriptableObject
{
    public string itemName; //������ �̸�
    public Sprite itemIcon; //������ ������
    public ItemType itemtype; //������ ����
    public int maxStack = 99; //������ �ִ� ���� ��
}

public enum ItemType
{ 
    Heal,           //ü��ȸ�� ������
    Placeable,      //��ġ�� ������
    Consumable      //�Ҹ�ǰ ������

}
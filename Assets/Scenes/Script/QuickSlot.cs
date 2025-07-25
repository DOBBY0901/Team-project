using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class QuickSlot : MonoBehaviour
{
    public Image iconImage;
    public TMP_Text keyText;

    [HideInInspector] public ItemData assigneditem; //등록된 아이템

    public void SetKeyText(string displayText)
    {
        keyText.text = displayText; //1~9,0
    }


    public void SetItem(ItemData item)
    {
        assigneditem = item;
        if (item != null)
        {
            iconImage.sprite = item.itemIcon;
            iconImage.enabled = true;
        }
        else
        {
            iconImage.sprite = null;
            iconImage.enabled = false; 
        }


    }

    public void UseItem()
    {
        if (assigneditem != null)
        {
            Debug.Log($"{assigneditem.itemName}을(를) 사용하였습니다.");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    public Image iconImage; //슬롯안의 아이콘 이미지
    public TMP_Text countText;  //우측상단의 개수 (X개)

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
}

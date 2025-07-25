using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    public Image iconImage; //���Ծ��� ������ �̹���
    public TMP_Text countText;  //��������� ���� (X��)

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
}

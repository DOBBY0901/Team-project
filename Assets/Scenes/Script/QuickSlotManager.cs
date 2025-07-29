using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class QuickSlotManager : MonoBehaviour
{
    public QuickSlot[] quickSlots; //10개의 슬롯 등록


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < quickSlots.Length; i++)
        {
            if (i < 9)
                quickSlots[i].SetKeyText((i + 1).ToString());

            else
                quickSlots[i].SetKeyText("0");
            
        }


    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 9; i++)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                quickSlots[i].UseItem();
            }

            if(Input.GetKeyDown(KeyCode.Alpha0))
            {
                quickSlots[9].UseItem();
            }
        }
    }
}

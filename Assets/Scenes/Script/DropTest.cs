using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTest : MonoBehaviour
{
    public DropTable testTable; //��� ���̺�
    public Inventory inventory; //�κ��丮

    void Update()
    {
    if (Input.GetKeyDown(KeyCode.Space))
        {
            //��� ���̺��� ������ �̱�
            var drop = testTable.GetRandomItem();
                
            if (drop.Item1 != null)
            {
                Debug.Log($"��� : {drop.Item1.itemName} x {drop.Item2}");

                //�κ��丮�� �߰�
                inventory.AddItem(drop.Item1, drop.Item2);
            }

            else
            {
                Debug.Log("����� ������ ����");
            }
        }
        
    }
}

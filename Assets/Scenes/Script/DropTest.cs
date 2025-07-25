using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTest : MonoBehaviour
{
    public DropTable testTable; //드랍 테이블
    public Inventory inventory; //인벤토리

    void Update()
    {
    if (Input.GetKeyDown(KeyCode.Space))
        {
            //드랍 테이블에서 아이템 뽑기
            var drop = testTable.GetRandomItem();
                
            if (drop.Item1 != null)
            {
                Debug.Log($"드랍 : {drop.Item1.itemName} x {drop.Item2}");

                //인벤토리에 추가
                inventory.AddItem(drop.Item1, drop.Item2);
            }

            else
            {
                Debug.Log("드랍된 아이템 없음");
            }
        }
        
    }
}

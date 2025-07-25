using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDropTable", menuName = "Drop Table")]
public class DropTable : ScriptableObject
{
    [System.Serializable]
    public class DropEntry
    {
        public ItemData item; //드랍 아이템
        [Range(0f, 1f)]
        public float chance;  //드랍 확률
        public int amount = 1;//드랍 개수

    }

    public DropEntry[] entries;

    //아이템이 하나라도 드랍되면 다른 아이템은 드랍하지 않음

    public (ItemData, int) GetRandomItem()
    {
        foreach(var entry in entries)
        {
            if(Random.value <= entry.chance)
            {
                return (entry.item, entry.amount);
            }
        }

        return (null, 0);
    }
}

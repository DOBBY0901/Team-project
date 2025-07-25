using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDropTable", menuName = "Drop Table")]
public class DropTable : ScriptableObject
{
    [System.Serializable]
    public class DropEntry
    {
        public ItemData item; //��� ������
        [Range(0f, 1f)]
        public float chance;  //��� Ȯ��
        public int amount = 1;//��� ����

    }

    public DropEntry[] entries;

    //�������� �ϳ��� ����Ǹ� �ٸ� �������� ������� ����

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

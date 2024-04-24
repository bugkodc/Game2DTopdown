using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class ItemSlot
{
    public ItemData item;
    public int count;
    public void Copy(ItemSlot slot)
    {
        item = slot.item;
        count = slot.count;
    }
    public void Set(ItemData item , int count)
    {
        this.item = item;
        this.count = count; 
    }
    public void Clear()
    {
        item = null;
        count = 0;
    }
}


[CreateAssetMenu(menuName = "Data/Item/itemContainer")]
public class ItemContainerData : ScriptableObject
{
    public List<ItemSlot> slots;
    public void Add(ItemData item, int count = 1)
    {
        if(item.stackable == true)
        {
            ItemSlot itemSlots = slots.Find(x => x.item == item);
            if (itemSlots != null)
            {
                itemSlots.count += count;
            }
            else
            {
                itemSlots = slots.Find(x => x.item == null);
                if (itemSlots != null)
                {
                    itemSlots.item = item;
                    itemSlots.count = count;
                }

            }
        }
        else
        {
            ItemSlot itemSlots = slots.Find(x => x.item == null);
            if(itemSlots != null)
            {
                itemSlots.item = item;
            }
        }
    }

}

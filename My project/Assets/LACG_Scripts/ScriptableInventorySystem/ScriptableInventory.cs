using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableInventory : MonoBehaviour
{
    public static event Action<List<InventoryItem>> OnInventoryChanged;

    public List<InventoryItem> inventory = new List<InventoryItem>();

    private Dictionary<ItemData, InventoryItem> itemDictionary = new Dictionary<ItemData, InventoryItem>();


    private void OnEnable()
    {
        CubeCollect.Collected += Add;
    }
    private void OnDisable ()
    {
          CubeCollect.Collected -= Add;
    }
    public void Add(ItemData itemData)
    {
        if(itemDictionary.TryGetValue(itemData, out InventoryItem item)) 
        {
            item.AddToStack();
            Debug.Log($" {item.itemData.displayName} total stack is now {item.StackSize}");
            OnInventoryChanged?.Invoke(inventory);
        }
        else
        {

            InventoryItem newItem = new InventoryItem(itemData);
            inventory.Add(newItem);
            itemDictionary.Add(itemData, newItem);
            Debug.Log($" Added {itemData.displayName} to the inventory for the first time");
            OnInventoryChanged?.Invoke(inventory);
        }
    }


    public void Remove(ItemData itemData) 
    {


        if (itemDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            item.RemoveFromStack();
            if(item.StackSize == 0)
            {
                inventory.Remove(item);
                itemDictionary.Remove(itemData);
            }
            OnInventoryChanged?.Invoke(inventory);
        }
        

    }
}

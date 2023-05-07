using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject slotPrefab;
    public List<Inventory_Slot> inventorySlots = new List<Inventory_Slot>(4);

    private void OnEnable()
    {
        ScriptableInventory.OnInventoryChanged += DrawInventory;
    }
    private void OnDisable()
    {
        ScriptableInventory.OnInventoryChanged -= DrawInventory;
    }
    void ResetInventory ()
     {
        foreach(Transform childTransform in transform) 
        {
            Destroy(childTransform.gameObject);
        
        }    
        inventorySlots = new List<Inventory_Slot> (4);
     }

    void DrawInventory(List<InventoryItem> inventory)
    {
        ResetInventory ();

        for(int i = 0; i < inventory.Capacity; i++) 
        {
            CreateInventorySlot();
        }

        for(int i = 0; i < inventory.Count; ++i)
        {
            inventorySlots[i].DrawSlot(inventory[i]);
        }
    }

    void CreateInventorySlot()
    {
        GameObject newSlot = Instantiate(slotPrefab);
        newSlot.transform.SetParent(transform, false);

        Inventory_Slot newSlotComponent = newSlot.GetComponent<Inventory_Slot>();
        newSlotComponent.ClearSlot();
        inventorySlots.Add(newSlotComponent);
    }

    
}

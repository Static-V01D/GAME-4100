using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour {

    [SerializeField] private Transform player;
    [SerializeField] private UI_Inventory uiInventory;

   private void Start () 
    {
       CraftingSystem craftingSystem = new CraftingSystem();
        Item item = new Item { itemType = Item.ItemType.Sword, amount = 1 };
        craftingSystem.SetItem(item, 0, 0);
        Debug.Log(craftingSystem.GetItem(0,0));
    
    
    }
  

}

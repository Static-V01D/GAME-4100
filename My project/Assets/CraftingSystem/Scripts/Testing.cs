
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour {

    [SerializeField] private CharacterController player;
    [SerializeField] private UI_Inventory uiInventory;

   

    [SerializeField] private CraftingSystem uiCraftingSystem;

    private void Start()
    {
        CraftingSystem craftingsystem = new CraftingSystem();
        Item item = new Item { itemType = Item.ItemType.Sword, amount = 1};
        craftingsystem.SetItem(item, -6, -4);
        Debug.Log(craftingsystem.GetItem(-6, -4));


    }

}

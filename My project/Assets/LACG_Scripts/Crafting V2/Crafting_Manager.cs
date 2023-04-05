using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Crafting_Manager : MonoBehaviour
{
    private Crafting_Item currentItem;
    public Image customCursor;

    public Slot[] craftingSlots;

    public List<Crafting_Item> itemList;
    public string[] recipes;
    public Crafting_Item[] recipesResults;
    public Slot resultSlot;

    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            if (currentItem != null)
            {
                customCursor.gameObject.SetActive(false);
                Slot nearestSlot = null;
                float shortestDistance = float.MaxValue;

                foreach(Slot slot in craftingSlots) 
                {
                   float dist = Vector2.Distance(Input.mousePosition, slot.transform.position);
                    
                    if (dist < shortestDistance) 
                    {
                    
                      shortestDistance = dist;
                        nearestSlot = slot;
                    }
                
                }
                nearestSlot.gameObject.SetActive(true);
                nearestSlot.GetComponent<Image>().sprite = currentItem.GetComponent<Image>().sprite;
                nearestSlot.item = currentItem;
                itemList[nearestSlot.index] = currentItem;
                currentItem = null;

                CheckForCreatedRecepies();
            }
        }
    }

    void CheckForCreatedRecepies()
    {
        resultSlot.gameObject.SetActive(false);
        resultSlot.item = null;

        string currentRecipeString = "";
        foreach(Crafting_Item item in itemList)
        {
            if(item != null)
            {
                currentRecipeString += item.ItemName;
            }
            else
            {
                currentRecipeString += "null";
            }
        }

        for(int i = 0; i < recipes.Length; i++) 
        {
            if (recipes[i] ==currentRecipeString)
            {
                resultSlot.gameObject.SetActive(true);
                resultSlot.GetComponent<Image>().sprite = recipesResults[i].GetComponent<Image>().sprite;
                resultSlot.item = recipesResults[i];
            
            }
        
        
        }
    }

    public void OnClickSlot(Slot slot)
    {
        
        slot.item = null;
        itemList[slot.index] = null;
        slot.gameObject.SetActive(false);
        CheckForCreatedRecepies();

    }
    public void OnMouseDownItem(Crafting_Item item)
    {
        if (currentItem == null)
        {
            currentItem = item;
            customCursor.gameObject.SetActive(true);
            customCursor.sprite = currentItem.GetComponent<Image>().sprite;
         
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject droppedItemPrefab;
    public List<loot> lootlist = new List<loot>();

  
    loot GetDroppedItem()
    {
        int randomNumber = Random.Range(1,101); // makes range = 1 to 100

        List < loot> possibleItems = new List<loot>();
        foreach (loot item in lootlist)
        {
            if(randomNumber <= item.dropChance) 
            {
                possibleItems.Add(item);
                
            
            }
        }
        if(possibleItems.Count > 0) 
        {
            loot droppedItem = possibleItems[Random.Range(0,possibleItems.Count)];
            return droppedItem;
        
        }
        Debug.Log("No loot dropped");
        return null;
    }


    public void InstantiateLoot(Vector3 spawnPosition)
    {
        loot droppedItem = GetDroppedItem();
        if( droppedItem != null ) 
        {
        
            GameObject lootGameObject = Instantiate(droppedItemPrefab, spawnPosition, Quaternion.identity);
            lootGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.lootSprite;

            float droppForce = 50f;

            Vector3 dropDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            lootGameObject.GetComponent<Rigidbody2D>().AddForce(dropDirection * droppForce, ForceMode2D.Impulse);
        }
    }
}

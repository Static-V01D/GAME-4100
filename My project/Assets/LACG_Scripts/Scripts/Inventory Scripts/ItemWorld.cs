using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.U2D;
using CodeMonkey.Utils;

public class ItemWorld : MonoBehaviour
{

    public static ItemWorld SpawnItemWorld(Vector3 position,Item item)
    {
       Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);

        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);

        return itemWorld;
    }

    public static ItemWorld DropItem(Vector3 dropPosition , Item item)
    {
        Vector3 RandomDir = UtilsClass.GetRandomDir();
       ItemWorld itemWorld = SpawnItemWorld(dropPosition + RandomDir * 5f, item);
        itemWorld.GetComponent<Rigidbody>().AddForce(RandomDir * 5, ForceMode.Impulse);
        return itemWorld;
    }
    private Item item;
    
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void SetItem (Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
    }

    public Item GetItem() 
    {
        return item;
    
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item 
{ 
    public enum ItemType
    {
        Sword,
        HealthPotion,
        Manapotion,
        Coin,
        Medkit,

    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType) 
        {
            default:
            case ItemType.Sword: return ItemAssets.Instance.swordSprite;
            case ItemType.HealthPotion: return ItemAssets.Instance.healthPotionSprite;
            case ItemType.Manapotion: return ItemAssets.Instance.manaPotionSprite;
            case ItemType.Coin: return ItemAssets.Instance.coinSprite;
            case ItemType.Medkit: return ItemAssets.Instance.medKitSprite;
        }
    }

    public bool IsStackable()
    {
        switch(itemType) 
        {
            default:
            case ItemType.Coin:
            case ItemType.Manapotion:
            case ItemType.HealthPotion:
                return true;      
               
            case ItemType.Medkit:
            case ItemType.Sword:
                return false;
        }
    }
  /*  public Color GetColor() 
    {
        switch(itemType) 
        {
            
            default:
            case ItemType.Sword: return new Color(0, 0, 0);
            case ItemType.HealthPotion: return new Color(1, 0, 0);
            case ItemType.Manapotion: return new Color(0, 0, 1);
            case ItemType.Coin: return new Color(1, 1, 0);
            case ItemType.Medkit: return new Color(0, 1, 1);

        }
    }*/
}

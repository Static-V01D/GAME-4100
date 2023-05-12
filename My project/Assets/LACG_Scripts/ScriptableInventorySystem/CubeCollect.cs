using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//using UnityEditor.Experimental.GraphView;

public class CubeCollect : MonoBehaviour, ICollectible
{
    public static event HandleCubeCollect Collected;

    public delegate void HandleCubeCollect(ItemData itemData);
    public ItemData itemData;
   
    public void Collect()
    {
        Destroy(gameObject);
        Collected?.Invoke(itemData);
    }
}

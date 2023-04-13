using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    
    public GameObject item;
    private Transform player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void SpawnDroppedItem()
    {
       Vector3 playerPos = new Vector3(player.position.x, player.position.y + 1, player.position.z + 0.3f);
        Instantiate(item, playerPos, Quaternion.identity);
    }



   
}

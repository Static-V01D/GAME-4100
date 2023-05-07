using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Numbers : MonoBehaviour, IInteractable
{
     public GameObject droppedItemPrefab;
   
    public void Interact()
    {
        Debug.Log(Random.Range(0, 100));
        Drop();
        
    }

    public void Drop ()
    {
        GameObject lootGameObject = Instantiate(droppedItemPrefab, transform.position * 1.1f, Quaternion.identity);


        float droppForce = 50f;

        Vector3 dropDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        lootGameObject.GetComponent<Rigidbody>().AddForce(dropDirection * droppForce, ForceMode.Impulse);
    }
}



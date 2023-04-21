using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject Enemy;
    public float xPos;
    public float zPos;
    public int enemyCount;


    void Start()
    {
        StartCoroutine(EnemyDrop());
    }


    IEnumerator EnemyDrop() 
    {
        while(enemyCount < 10)
        {
            xPos = Random.Range(-14, -13);
            zPos = Random.Range(5, 4);
            Instantiate(Enemy, new Vector3(xPos,-0.8f ,zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
        
    
    }
  
}

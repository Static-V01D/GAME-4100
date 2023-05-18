using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WallHealth : MonoBehaviour
{
    [SerializeField] private float health;   
    public GameObject Wall2;
    public GameObject Wall1;
    public GameObject Wall3;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health--;
        }
    }   
    private void Update()
    {
        if (health <= 2)
        {
            Wall1.SetActive(false);
            Wall2.SetActive(true);
           
        }
       else if (health <= 1)
        {
            Wall2.SetActive(false);
            Wall3.SetActive(true);
           
        }
       else if (health == 0)
        {
            Wall3.SetActive(false);
           
           
        }
    }
  
}

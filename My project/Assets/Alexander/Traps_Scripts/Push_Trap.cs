using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push_Trap : MonoBehaviour
{
    private GameObject Push_trap;
    Transform Enemy;
    Transform Agent;
    //public int Push_Force;
    public float force = 700f;
    private float radius = 5f;
    public float thrust = 700.0f;
          public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    
    void Update()
    {
        
    }    
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Agent")) 
        {
            transform.localEulerAngles = new Vector3(-90f, 0f, 0f);

            other.gameObject.GetComponent<Rigidbody>().AddForce(force * Vector3.up, ForceMode.Impulse);
        }
    }
   
}

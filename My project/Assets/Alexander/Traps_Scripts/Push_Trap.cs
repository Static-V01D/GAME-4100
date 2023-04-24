using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push_Trap : MonoBehaviour
{
    private GameObject Push_trap;
    public int Push_Force;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter(Collider other)
    {


        //anything with the enemy tag the mine will activate
        if (other.tag == "Agent")
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 1000.0f);
            //transform.Rotate(-90f, 0f, 0f, Space.Self);
            transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
            //transform.localEulerAngles = new Vector3(0f, 0f, 0f);

            //Finds the object
            Push_trap = GameObject.Find("Agent");
            
            

        }
    }
}

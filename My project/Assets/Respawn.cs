using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    public float threshold;

    private void FixedUpdate()
    {
        if(transform.position.y < threshold)
        {
            transform.position = new Vector3(-8.089569f, 4.768372e-07f, -19.24872f);
        }
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Advanced_Proyectile : MonoBehaviour
//{
//    [SerializeField] private float speed;
//    [SerializeField] private float resetTime;
//    private float lifetime;
//    public void ActivateProyectile() 
//    {
//        lifetime = 0;
//        gameObject.SetActive(true);
//    }

//    private void Update()
//    {
//        float movementspeed = speed * Time.deltaTime;
//        transform.Translate(movementspeed, 0, 0);

//        lifetime += Time.deltaTime;
//        if (lifetime > resetTime)
//            gameObject.SetActive(false);
//    }
//    private void OnTriggerEnter(Collider other)
//    {
//        gameObject.SetActive(false);
//    }
//}

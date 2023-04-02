//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Proyectile : MonoBehaviour
//{
//    [SerializeField] private float speed;
//    private float direction;
//    private bool hit;
//    private float lifetime;

//    private BoxCollider boxCollider;

//    private void Awake()
//    {
//        boxCollider = GetComponent<BoxCollider>();
//    }

//    private void Update()
//    {
//        if (hit) return;
//        float movementSpeed = speed * Time.deltaTime * direction;
//        transform.Translate(movementSpeed, 0, 0);

//        lifetime += Time.deltaTime;
//        if (lifetime > 5) gameObject.SetActive(false);
//    }
//}

 

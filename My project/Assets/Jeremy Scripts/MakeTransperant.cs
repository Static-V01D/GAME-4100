using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTransperant : MonoBehaviour
{

    [SerializeField] private List<CurrentlyInTheWay> currentlyInTheWay;
    [SerializeField] private List<CurrentlyInTheWay> alreadyTransperant;
    [SerializeField] private Transform player;
    private GameObject cameraObject;
    private Transform camera;

    private void Awake()
    {
        currentlyInTheWay = new List<CurrentlyInTheWay>();
        alreadyTransperant = new List<CurrentlyInTheWay>();

        cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        camera = cameraObject.GetComponent<Transform>();
    }

    private void Update()
    {
        GetAllObjectsInTheWay();

        MakeObjectsSolid();
        MakeObjectsTransperant();
    }

    private void GetAllObjectsInTheWay()
    {
        currentlyInTheWay.Clear();

        float cameraPlayerDistance = Vector3.Magnitude(camera.position - player.position);

        Ray ray1_Forward = new Ray(camera.position, player.position - camera.position);
        Ray ray1_Backward = new Ray(camera.position, player.position - camera.position);


        var hits1_Forward = Physics.RaycastAll(ray1_Forward, cameraPlayerDistance);
        var hits1_Backward = Physics.RaycastAll(ray1_Backward, cameraPlayerDistance);

        foreach (var hit in hits1_Forward)
        {
            if (hit.collider.gameObject.TryGetComponent(out CurrentlyInTheWay inTheWay))
            {
                if(!currentlyInTheWay.Contains(inTheWay))
                {
                    currentlyInTheWay.Add(inTheWay);
                }
            }
        }

        foreach(var hit in hits1_Backward)
        {
            if (hit.collider.gameObject.TryGetComponent(out CurrentlyInTheWay inTheWay))
            {
                if(!currentlyInTheWay.Contains(inTheWay))
                {
                    currentlyInTheWay.Add(inTheWay);
                }
            }
        }

    }

    private void MakeObjectsTransperant()
    {
        for(int i = 0; i < currentlyInTheWay.Count; i++)
            {
                CurrentlyInTheWay inTheWay = currentlyInTheWay[i];
                if(!alreadyTransperant.Contains(inTheWay))
                {
                    inTheWay.ShowTransperant();
                    alreadyTransperant.Add(inTheWay);
                }
            }
    }

    private void MakeObjectsSolid()
    {

        for(int i = alreadyTransperant.Count-1; i >= 0; i--)
            {
                CurrentlyInTheWay wasInTheWay = alreadyTransperant[i];

                if(!currentlyInTheWay.Contains(wasInTheWay))
                {
                    wasInTheWay.ShowSolid();
                    alreadyTransperant.Remove(wasInTheWay);
                }
            }

    }

}
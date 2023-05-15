using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeInvisible : MonoBehaviour
{
    [SerializeField] private List<InTheWay> currentlyInTheWay;
    [SerializeField] private List<InTheWay> alreadyTransperant;
    [SerializeField] private Transform player;
    private GameObject cameraObject;
    private Transform mainCamera;

    private void Awake()
    {
        currentlyInTheWay = new List<InTheWay>();
        alreadyTransperant = new List<InTheWay>();

        cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        mainCamera = cameraObject.GetComponent<Transform>();
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

        float cameraPlayerDistance = Vector3.Magnitude(mainCamera.position - player.position);

        Ray ray1_Forward = new Ray(mainCamera.position, player.position - mainCamera.position);
        Ray ray1_Backward = new Ray(mainCamera.position, player.position - mainCamera.position);


        var hits1_Forward = Physics.RaycastAll(ray1_Forward, cameraPlayerDistance);
        var hits1_Backward = Physics.RaycastAll(ray1_Backward, cameraPlayerDistance);

        foreach (var hit in hits1_Forward)
        {
            if (hit.collider.gameObject.TryGetComponent(out InTheWay inTheWay))
            {
                if (!currentlyInTheWay.Contains(inTheWay))
                {
                    currentlyInTheWay.Add(inTheWay);
                    Debug.Log("Funciona");
                }
            }
        }

        foreach (var hit in hits1_Backward)
        {
            if (hit.collider.gameObject.TryGetComponent(out InTheWay inTheWay))
            {
                if (!currentlyInTheWay.Contains(inTheWay))
                {
                    currentlyInTheWay.Add(inTheWay);
                    Debug.Log("Funciona");

                }
            }
        }

    }

    private void MakeObjectsTransperant()
    {
        for (int i = 0; i < currentlyInTheWay.Count; i++)
        {
            InTheWay inTheWay = currentlyInTheWay[i];
            if (!alreadyTransperant.Contains(inTheWay))
            {
                inTheWay.ShowTransperant();
                alreadyTransperant.Add(inTheWay);
                Debug.Log("Funciona");
            }
            else
            {
                Debug.Log("No Funciona");
            }
        }
    }

    private void MakeObjectsSolid()
    {

        for (int i = alreadyTransperant.Count - 1; i >= 0; i--)
        {
            InTheWay wasInTheWay = alreadyTransperant[i];

            if (!currentlyInTheWay.Contains(wasInTheWay))
            {
                wasInTheWay.ShowSolid();
                alreadyTransperant.Remove(wasInTheWay);
                Debug.Log("Funciona");
            }
            else
            {
                Debug.Log("No Funciona");
            }
        }

    }
}

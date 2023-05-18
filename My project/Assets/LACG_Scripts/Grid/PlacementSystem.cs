using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] 
    private GameObject mouseIndicator, cellIndicator;

    [SerializeField]
    private InputManager inputManager;

    [SerializeField]
    private Grid grid;


    [SerializeField]
    private ObjectsDataBaseSO database;
    private int selectedObjectIndex = -1;



    [SerializeField]
    private GameObject gridVisualization;

    private GridData floorData, TrapData;

    private Renderer previewRenderer;

    private List<GameObject> placedGameOject =  new();

    private void Start()
    {
        StopPlaceMent();
        floorData = new();
        TrapData = new();
        previewRenderer = cellIndicator.GetComponent<Renderer>();
    }

    public void StartPlaceMent(int ID)
    {
        selectedObjectIndex = database.objectsData.FindIndex(data => data.ID == ID);
        if(selectedObjectIndex < 0) 
        {
            Debug.LogError($"No ID FOund{ID}");
            return;
        }
        gridVisualization.SetActive(true);
        cellIndicator.SetActive(true);
        inputManager.OnClicked += PlaceStructure;
        inputManager.OnExit += PlaceStructure;
    }

    private void PlaceStructure()
    {
        if(inputManager.isPointerOverUI())
        {
            return;
        }
        Vector3 mouseposition = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mouseposition);

        bool placementValidity = CheckPlacementValidity(gridPosition, selectedObjectIndex);
        if(placementValidity == false) 
        {
            return;        
        }
        GameObject newObject = Instantiate(database.objectsData[selectedObjectIndex].Prefab);
        newObject.transform.position = grid.CellToWorld(gridPosition);
        placedGameOject.Add( newObject );
        GridData selectedData = database.objectsData[selectedObjectIndex].ID == 0 ? floorData : TrapData;
        selectedData.AddObjectAt(gridPosition,database.objectsData[selectedObjectIndex].Size,database.objectsData[selectedObjectIndex].ID, placedGameOject.Count - 1);
    }

    private bool CheckPlacementValidity(Vector3Int gridPosition, int selectedObjectIndex)
    {
        GridData selectedData = database.objectsData[selectedObjectIndex].ID == 0 ? floorData : TrapData;


        return selectedData.CanPlaceObjectAt(gridPosition, database.objectsData[selectedObjectIndex].Size);
    }

    private void StopPlaceMent()
    {
        selectedObjectIndex = -1;
        gridVisualization.SetActive(false);
        cellIndicator.SetActive(false);
        inputManager.OnClicked -= PlaceStructure;
        inputManager.OnExit -= StopPlaceMent;
    }

    private void Update()
    {
        if (selectedObjectIndex < 0)
            return;

        Vector3 mouseposition = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mouseposition);

       bool placementValidity = CheckPlacementValidity(gridPosition, selectedObjectIndex);
       previewRenderer.material.color = placementValidity ? Color.green : Color.red;

        mouseIndicator.transform.position = mouseposition;

       cellIndicator.transform.position = grid.CellToWorld(gridPosition);


    }
}



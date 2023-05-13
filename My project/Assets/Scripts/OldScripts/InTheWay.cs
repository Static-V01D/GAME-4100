using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InTheWay : MonoBehaviour
{
    [SerializeField] private GameObject solidBody;
    [SerializeField] private GameObject transperantBody;

    public List<GameObject> prefabs = new List<GameObject>();
    void Start()
    {
        GameObject[] objs = Resources.LoadAll<GameObject>("");
        foreach (GameObject obj in objs)
        {
            if (obj.scene.name == null)
            {
                prefabs.Add(obj);
            }
        }
    }


    private void Awake()
    {
        ShowSolid();
    }

    public void ShowTransperant()
    {

        solidBody.SetActive(false);
        transperantBody.SetActive(true);

    }

    public void ShowSolid()
    {
        solidBody.SetActive(true);
        transperantBody.SetActive(false);
    }
}

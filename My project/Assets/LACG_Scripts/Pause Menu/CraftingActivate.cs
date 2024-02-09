using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CraftingActivate : MonoBehaviour
{
    public GameObject craftingMenu;
    public bool IsCrafting;

    void Start()
    {
        craftingMenu.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.C))
        {
            if (IsCrafting)
            {

                NotCrafting();
            }
            else
            {
                Crafting();
            }
        }

    }

    public void Crafting()
    {
        craftingMenu.SetActive(true);

        IsCrafting = true;
    }

    public void NotCrafting()
    {
        craftingMenu.SetActive(false);

        IsCrafting = false;
    }

}



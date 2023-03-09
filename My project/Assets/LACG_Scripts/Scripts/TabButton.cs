using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


[RequireComponent(typeof(image))]
public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public TabGroup tabGroup;

    public Image background;

    public void OnTabEnter(TabButton button)
    {
        tabGroup.OnTabEnter(button);
    }


    public void OnTabExit(TabButton button)
    {
        tabGroup.OnTabExit(button);
    }

    public void OnTabSelected(TabButton button)
    {
        tabGroup.OnTabSelected(button); 
    }


    void Start()
    {
        background = GetComponent<Image>();
        tabGroup.Subscribe(this);

    }
}

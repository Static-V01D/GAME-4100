using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;


[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public TabGroup tabGroup;

    public Image background;


    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        tabGroup.OnTabSelected(this);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        tabGroup.OnTabEnter(this);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        tabGroup.OnTabExit(this);
    }

    void Start()
    {
        background = GetComponent<Image>();
        tabGroup.Subscribe(this);

    }
}

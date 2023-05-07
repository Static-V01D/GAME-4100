using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Slot : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI labelTxt;
    public TextMeshProUGUI stackSizeTxt;


    public void ClearSlot()
    {

        icon.enabled = false;
        labelTxt.enabled = false;
        stackSizeTxt.enabled = false;
    }

    public void DrawSlot(InventoryItem item)
    {
        if (item == null)
        {
            ClearSlot();
            return;
        }
        icon.enabled = true;
        labelTxt.enabled = true;
        stackSizeTxt.enabled = true;


        icon.sprite = item.itemData.icon;
        labelTxt.text = item.itemData.displayName;
        stackSizeTxt.text = item.StackSize.ToString();
    }







}

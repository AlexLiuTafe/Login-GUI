using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    #region Variables
    public Text myButtonText;
    public int index;
    public RawImage itemIcon;
    public Text itemName;
    public Text itemDescription;
    #endregion
    void Start()
    {
        
    }

    
    void Update()
    {
        //getiing references to UI elements that will be holding different info        
        myButtonText = GetComponentInChildren<Text>();
        itemIcon = GameObject.FindGameObjectWithTag("MainIcon").GetComponent<RawImage>();
        itemName = GameObject.FindGameObjectWithTag("ItemName").GetComponent<Text>();
        itemDescription = GameObject.FindGameObjectWithTag("ItemDesc").GetComponent<Text>();
    }

    /// <summary>
    /// This method will use index to access particular
    /// part index of the statci list inventory.
    /// This gets call by OnClick event
    /// </summary>
    public void ShowSelectedItem()
    {
        myButtonText.text = LinearCanvasInventory.inv[index].Name;
        itemIcon.texture = LinearCanvasInventory.inv[index].Icon;
        itemName.text = LinearCanvasInventory.inv[index].Name;
        itemDescription.text = LinearCanvasInventory.inv[index].Description;
    }
}

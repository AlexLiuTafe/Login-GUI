using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinearCanvasInventory : MonoBehaviour
{

    #region Variables
    public static List<Item> inv = new List<Item>();
    [Header("Inventory Parts")]
    public GameObject invPanel;
    public GameObject buttonPrefab;
    //public GameObject uiMainIcon;
    //public GameObject uiItemName;
    //public GameObject uiItemDesc;

    public RectTransform parent;
    [Header("Inventory Properties")]
    public bool toggleTogglable = false; // bool to determine if we show / hide inventory panel
    public int maxInventorySpace = 0;
    //this will match the inventory index. will be used for instanting the item in the correspoding  inv[] to the button we click
    public int selected = 0; 
    

    [System.Serializable]
    public struct equipment
    {
        public string name;
        public Transform location;
        public GameObject curItem;
    };
    public equipment[] equipmentSlots;
    private int slot; // this will the reference the correct equipmentSlots[]



    #endregion

    #region Internal
    void Start()
    {

    }


    void Update()
    {
        #region Show/Hide Inventory
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            toggleTogglable = !toggleTogglable;
            ShowInv();
        }

        if (toggleTogglable && Input.GetKeyDown(KeyCode.I) && maxInventorySpace < 9)
        {
            AddItemToInventory();
            maxInventorySpace++;
        }


        #endregion

    }
    #endregion


    #region External
    /// <summary>
    /// Simple show hide the LinearInvPanel
    /// </summary>
    public void ShowInv()
    {
        if (toggleTogglable)
        {
            invPanel.SetActive(true);
        }
        else
        {
            invPanel.SetActive(false);
        }
    }

    /// <summary>
    /// This method will spawn a button and will
    /// - create an item through Item.DataCreateItem and add it to the inventory
    /// - instantiate the prefeb button
    /// - set the buttons index matching the inv[index]
    /// - name the button with the item.Name
    /// - get component in childern to set the button text to item.Name
    /// </summary>
    public void AddItemToInventory()
    {
        inv.Add(ItemData.CreateItem(Random.Range(400, 403)));
        int currentSlot = inv.Count - 1;
        GameObject button = Instantiate(buttonPrefab, parent); //parent is the Gridlaout object
        button.GetComponent<SelectButton>().index = currentSlot;
        button.name = inv[currentSlot].Name;
        button.GetComponentInChildren<Text>().text = inv[currentSlot].Name;

        //check what equipmentSlots[]
        for (int i = 0; i < (int)ItemType.All; i++)
        {
            //note:  0 = head, 1 = hand, 2 = dropLocation
            switch ((ItemType)i)
            {
                
                case ItemType.Armour:
                    slot = 0;
                    break;
                case ItemType.Weapon:
                    slot = 1;
                    break;
                default:
                    break;
            }
        }


        // check to see if the respective slot is epmty or has SAME item
        if (equipmentSlots[slot].curItem == null || equipmentSlots[slot].curItem.name == inv[currentSlot].Name)
        {
            
            if (equipmentSlots[slot].curItem == null)
            {
                //if epmty show equip button
                //Debug.Log("Equip!!");
            }
            else
            {
                //else show unequip and discard button
                Debug.Log("Discard!!");
            }
        }
        else
        {
            //else its not empty but different item
            Debug.Log("Destroy then Equip!!");
        }

    }

    /// <summary>
    /// Useing the item Function:
    /// 
    /// </summary>
    public void UseItem(ItemType type)
    {
        switch (type)
        {
            case ItemType.Ingredient:
                break;
            case ItemType.Potion:
                break;
            case ItemType.Scroll:
                break;
            case ItemType.Food:
                break;
            case ItemType.Armour:
                break;
            case ItemType.Weapon:

                break;
            case ItemType.Craftable:
                break;
            case ItemType.Money:
                break;
            case ItemType.Quest:
                break;
            case ItemType.Misc:
                break;
            case ItemType.All:
                break;
            default:
                break;
        }
    }
    #endregion
}

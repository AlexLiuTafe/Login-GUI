using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropInventory : MonoBehaviour
{
    #region Variables
    [Header("Inventory")]
    public bool showInv;
    public List<Item> inv = new List<Item>();
    public int slotX = 7, slotY = 5;
    public Rect inventorySize;
    [Header("Dragging")]
    public bool isDragging;
    public int draggedFrom;
    public Item draggedItem;
    public GameObject droppedItem;
    [Header("ToolTip")]
    public int toolTipItem;
    public bool showToolTip;
    public Rect toolTipRect;
    [Header("References and Locations")]
    public Vector2 scr;
    #endregion
    #region Clamp to Screen
    private Rect ClampToScreen(Rect r)
    {
        r.x = Mathf.Clamp(r.x, 0, Screen.width - r.width);
        r.y = Mathf.Clamp(r.y, 0, Screen.height - r.height);

        return r;
    }
    #endregion
    #region Add Item
    public void AddItem(int itemID)
    {
        for (int i = 0; i < inv.Count; i++)
        {
            if(inv[i].Name == null)
            {
                inv[i] = ItemData.CreateItem(itemID);
                Debug.Log("Add Item: "+inv[i].Name);
                return;
            }
        }
    }
    #endregion
    #region Drop Item
    public void DropItem()
    {
        droppedItem = draggedItem.ItemMesh;
        droppedItem = Instantiate(droppedItem, transform.position + transform.forward * 3, Quaternion.identity);
        droppedItem.AddComponent<Rigidbody>().useGravity = true;
        droppedItem.name = draggedItem.Name;
        droppedItem = null;
    }
    #endregion
    #region Draw Item
    void DrawItem(int windowID)
    {
        if(draggedItem.Icon != null)
        {
            GUI.DrawTexture(new Rect(0,0,scr.x * 0.5f,scr.y*0.5f),draggedItem.Icon);
        }
    }
    #endregion

    #region ToolTip
    #region ToolTipContent
    private string ToolTipText(int index)
    {
        string toolTipText =
            inv[index].Name + "\n" +
            inv[index].Description +
            "\nValue: " +
            inv[index].Value;

        return toolTipText;
    }
    #endregion
    #region ToolTipWindow
    void DrawToolTip(int windowID)
    {
        GUI.Box(new Rect(0,0,scr.x*6,scr.y*2),ToolTipText(toolTipItem));
    }
    #endregion
    #endregion

    #region Toggle Inventory
    public void ToggleInv()
    {
        showInv = !showInv;
        if (showInv)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    #endregion
    #region Drag Inventory
    void InventoryDrag(int windowID)
    {
        GUI.Box(new Rect(0, scr.y * 0.25f, scr.x * 5.5f, scr.y * 0.5f), "Banner");
        GUI.Box(new Rect(0, scr.y * 4f, scr.x * 5.5f, scr.y * 0.5f), "Gold Display");
        showToolTip = false;
        #region Nested For Loop
        int i = 0;
        Event e = Event.current;
        for (int y = 0; y < slotY; y++)
        {
            for (int x = 0; x < slotX; x++)
            {
                Rect slotLocation = new Rect(
                    scr.x * 0.125f + x * (scr.x * 0.75f),
                     scr.y * 0.75f + y * (scr.y * 0.65f),
                     scr.x * 0.75f,
                     scr.y * 0.65f);
                GUI.Box(slotLocation, "");
                #region Pickup Item
                if(e.button == 0 && e.type == EventType.MouseDown && slotLocation.Contains(e.mousePosition) && !isDragging && inv[i].Name != null && !Input.GetKey(KeyCode.LeftShift))
                {
                    draggedItem = inv[i];
                    inv[i] = new Item();
                    isDragging = true;
                    draggedFrom = i;
                    Debug.Log("Currently dragging your "+draggedItem.Name);
                }
                #endregion
                #region Swap Item
                if(e.button == 0 && e.type == EventType.MouseUp && slotLocation.Contains(e.mousePosition) && isDragging && inv[i].Name != null)
                {
                    Debug.Log("Swapped your " + draggedItem.Name + " with " + inv[i].Name);
                    inv[draggedFrom] = inv[i];
                    inv[i] = draggedItem;
                    draggedItem = new Item();
                    isDragging = false;                   
                }
                #endregion
                #region Place Item
                if(e.button == 0 && e.type == EventType.MouseUp && slotLocation.Contains(e.mousePosition)&&isDragging && inv[i].Name == null)
                {
                    Debug.Log("Placing your "+draggedItem.Name);
                    inv[i] = draggedItem;
                    draggedItem = new Item();
                    isDragging = false;
                }
                #endregion
                #region Return Item
                
                #endregion
                #region Draw Item Icon
                if(inv[i].Name != null)
                {
                    GUI.DrawTexture(slotLocation, inv[i].Icon);
                    #region Set ToolTip on Mouse Hover
                    if(slotLocation.Contains(e.mousePosition) && !isDragging && showInv)
                    {
                        toolTipItem = i;
                        showToolTip = true;
                    }
                    #endregion
                }
                #endregion
                i++;
            }
        }
        #endregion
        #region Drag Points
        GUI.DragWindow(new Rect(0, 0, scr.x * 6, scr.y * 0.25f));//Top
        GUI.DragWindow(new Rect(0, scr.y*0.25f, scr.x * 0.25f, scr.y * 3.75f));//Left
        GUI.DragWindow(new Rect(scr.x*5.5f, scr.y*0.25f, scr.x * 0.25f, scr.y * 3.75f));//Right
        GUI.DragWindow(new Rect(0,scr.y*4, scr.x * 6, scr.y * 0.25f));//Bottom
        #endregion
    }
    #endregion

    #region Start
    private void Start()
    {
        scr.x = Screen.width / 16;
        scr.y = Screen.height / 9;
        inventorySize = new Rect(scr.x,scr.y,scr.x *5.5f, scr.y*4.5f);
        for (int i = 0; i < (slotX*slotY); i++)
        {
            inv.Add(new Item());
        }
        AddItem(0);
        AddItem(1);
        AddItem(2);
        AddItem(400);
        AddItem(500);
        AddItem(501);
    }
    #endregion
    #region Update
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInv();
        }
        if (scr.x != Screen.width / 16)
        {
            scr.x = Screen.width / 16;
            scr.y = Screen.height / 9;
            inventorySize = new Rect(scr.x, scr.y, scr.x * 5.5f, scr.y * 4.5f);
        }
    }
    #endregion
    #region OnGUI
    private void OnGUI()
    {
        Event e = Event.current;
        #region Inventory when true
        if(showInv)
        {
            inventorySize = ClampToScreen(GUI.Window(1, inventorySize,InventoryDrag,"Player Inventory"));
            #region ToolTipDisplay
            if(showToolTip)
            {
                toolTipRect = new Rect(e.mousePosition.x + 0.01f, e.mousePosition.y + 0.01f, scr.x * 6, scr.y * 2);
                GUI.Window(7, toolTipRect, DrawToolTip, "");
            }
            #endregion
        }
        #endregion
        #region Drop Item
        if((e.button == 0 && e.type == EventType.MouseUp && isDragging)||(isDragging && !showInv))
        {
            DropItem();
            Debug.Log("Dropped Item "+draggedItem.Name);
            draggedItem = new Item();
            isDragging = false;
        }
        #endregion
        #region Draw Item On Mouse
        if(isDragging)
        {
            if(draggedItem != null)
            {
                Rect mouseLocation = new Rect(e.mousePosition.x + 0.125f, e.mousePosition.y + 0.125f, scr.x * 0.5f, scr.y * 0.5f);
                GUI.Window(72,mouseLocation,DrawItem,"");
            }
        }
        #endregion
    }
    #endregion
}

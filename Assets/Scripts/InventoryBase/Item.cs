
using UnityEngine;

public class Item
{
    #region Private Variables
    private int _id;
    private string _name;
    private string _description;
    private int _amount;
    private int _value;
    private ItemType _type;
    private Texture2D _icon;
    private GameObject _mesh;

    private int _damage;
    private int _armour;
    private int _heal;
    #endregion
    #region Public Properties
    public int ID
    {
        get { return _id; }//Read
        set { _id = value; }//Write
    }
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    public int Amount
    {
        get { return _amount; }
        set { _amount = value; }
    }
    public int Value
    {
        get { return _value; }
        set { _value = value; }
    }
    public ItemType Type
    {
        get { return _type; }
        set { _type = value; }
    }
    public Texture2D Icon
    {
        get { return _icon; }
        set { _icon = value; }
    }
    public GameObject ItemMesh
    {
        get { return _mesh; }
        set { _mesh = value; }
    }
    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }
    public int Armour
    {
        get { return _armour; }
        set { _armour = value; }
    }
    public int Heal
    {
        get { return _heal; }
        set { _heal = value; }
    }
    #endregion

    #region External
    
    #endregion
}
public enum ItemType
{
    Ingredient = 0,
    Potion = 1,
    Scroll = 2,
    Food = 3,
    Armour,
    Weapon,
    Craftable,
    Money,
    Quest,
    Misc,
    All
}


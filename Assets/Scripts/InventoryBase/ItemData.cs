using UnityEngine;

public static class ItemData
{
    public static Item CreateItem(int itemID)
    {
        string _name = "";
        string _description = "";
        int _amount = 0;
        int _value = 0;
        ItemType _type = ItemType.Food;
        string _icon = "";
        string _mesh = "";
        int _damage = 0;
        int _armour = 0;
        int _heal = 0;

        switch (itemID)
        {
            #region Ingredient 000-099
            case 000:
                _name = "Acorn";
                _description = "Just Acorn";
                _amount = 1;
                _value = 1;
                _type = ItemType.Ingredient;
                //NOTE Dont forget to change the texture type of the Icon sprite in the inspector into "Editor GUI and Editor GUI"(because we are using hard coding)
                _icon = "Ingredient/Acorn";
                //NOTE Change the name of the icon name accordingly
                _mesh = "Ingredient/Acorn";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 001:
                _name = "Mushroom";
                _description = "Red Colored Mushroom that is common in the area";
                _amount = 1;
                _value = 3;
                _type = ItemType.Ingredient;
                _icon = "Ingredient/Mushroom";
                _mesh = "Ingredient/Mushroom";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 002:
                _name = "Leaf";
                _description = "Green Leaf that can be found in every season";
                _amount = 1;
                _value = 2;
                _type = ItemType.Ingredient;
                _icon = "Ingredient/Leaf";
                _mesh = "Ingredient/Leaf";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            #endregion
            #region Potion 100-199
            case 100:
                _name = "Purple Potion";
                _description = "Normal Potion";
                _amount = 1;
                _value = 5;
                _type = ItemType.Potion;
                _icon = "Potion/PurplePotion";
                _mesh = "Potion/PurplePotion";
                _damage = 0;
                _armour = 0;
                _heal = 5;
                break;
            case 101:
                _name = "Yellow Potion";
                _description = "Medium Potion";
                _amount = 1;
                _value = 8;
                _type = ItemType.Potion;
                _icon = "Potion/YellowPotion";
                _mesh = "Potion/YellowPotion";
                _damage = 0;
                _armour = 0;
                _heal = 10;
                break;
            case 102:
                _name = "Red Potion";
                _description = "Large Potion";
                _amount = 1;
                _value = 10;
                _type = ItemType.Potion;
                _icon = "Potion/RedPotion";
                _mesh = "Potion/RedPotion";
                _damage = 0;
                _armour = 0;
                _heal = 15;
                break;
            #endregion
            #region Scroll 200-299
            case 200:
                _name = "Knowledge Scroll";
                _description = "A scroll that improve the character knowledege for 5 mins";
                _amount = 1;
                _value = 15;
                _type = ItemType.Scroll;
                _icon = "Scroll/KnowledgeScroll";
                _mesh = "Scroll/KnowledgeScroll";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 201:
                _name = "Strength Scroll";
                _description = "A scroll that improve the character strength for 5 mins";
                _amount = 1;
                _value = 15;
                _type = ItemType.Scroll;
                _icon = "Scroll/StrengthScroll";
                _mesh = "Scroll/StrengthScroll";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 202:
                _name = "Speed Scroll";
                _description = "A scroll that improve the character speed for 5 mins";
                _amount = 1;
                _value = 15;
                _type = ItemType.Scroll;
                _icon = "Scroll/SpeedScroll";
                _mesh = "Scroll/SpeedScroll";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            #endregion
            #region Armour 300-399
            case 300:
                _name = "Hunter Vest";
                _description = "A leather type of armour that light in material";
                _amount = 1;
                _value = 50;
                _type = ItemType.Armour;
                _icon = "Armour/HunterVest";
                _mesh = "Armour/HunterVest";
                _damage = 0;
                _armour = 10;
                _heal = 0;
                break;
            case 301:
                _name = "Hunter Braces";
                _description = "A leather type of armour that light in material";
                _amount = 1;
                _value = 20;
                _type = ItemType.Armour;
                _icon = "Armour/HunterBraces";
                _mesh = "Armour/HunterBraces";
                _damage = 0;
                _armour = 4;
                _heal = 0;
                break;
            case 302:
                _name = "Hunter Helm";
                _description = "A leather type of armour that light in material";
                _amount = 1;
                _value = 35;
                _type = ItemType.Armour;
                _icon = "Armour/HunterHelm";
                _mesh = "Armour/HunterHelm";
                _damage = 0;
                _armour = 7;
                _heal = 0;
                break;
            #endregion
            #region Weapon 400-499
            case 400:
                _name = "Crossbow";
                _description = "A long range weapon";
                _amount = 1;
                _value = 50;
                _type = ItemType.Weapon;
                _icon = "Weapon/Crossbow";
                _mesh = "Weapon/Crossbow";
                _damage = 15;
                _armour = 0;
                _heal = 0;
                break;
            case 401:
                _name = "Sword";
                _description = "Only For the Choosen One";
                _amount = 1;
                _value = 50;
                _type = ItemType.Weapon;
                _icon = "Weapon/Sword";
                _mesh = "Weapon/Sword";
                _damage = 18;
                _armour = 0;
                _heal = 0;
                break;
            case 402:
                _name = "Staff";
                _description = "A Magic type of weapon";
                _amount = 1;
                _value = 50;
                _type = ItemType.Weapon;
                _icon = "Weapon/Staff";
                _mesh = "Weapon/Staff";
                _damage = 20;
                _armour = 0;
                _heal = 0;
                break;
            #endregion
            #region Food 500-599
            case 500:
                _name = "Shrimp";
                _description = "A bounty from the sea";
                _amount = 1;
                _value = 5;
                _type = ItemType.Food;
                _icon = "Food/Shrimp";
                _mesh = "Food/Shrimp";
                _damage = 0;
                _armour = 0;
                _heal = 15;
                break;
            case 501:
                _name = "Meat";
                _description = "A Hearty Meal of Caveman";
                _amount = 1;
                _value = 5;
                _type = ItemType.Food;
                _icon = "Food/Meat";
                _mesh = "Food/Meat";
                _damage = 0;
                _armour = 0;
                _heal = 20;
                break;
            case 502:
                _name = "Brocoli";
                _description = "A healthy vegetable from a garden";
                _amount = 1;
                _value = 5;
                _type = ItemType.Food;
                _icon = "Food/Broccoli";
                _mesh = "Food/Broccoli";
                _damage = 0;
                _armour = 0;
                _heal = 10;
                break;
            #endregion
            #region Money 600-699
            case 600:
                _name = "Copper Coin";
                _description = "Lowest value coin";
                _amount = 1;
                _value = 1;
                _type = ItemType.Money;
                _icon = "Money/CopperCoin";
                _mesh = "Money/CopperCoin";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 601:
                _name = "Silver Coin";
                _description = "Moderate value coin";
                _amount = 1;
                _value = 50;
                _type = ItemType.Money;
                _icon = "Money/SilverCoin";
                _mesh = "Money/SilverCoin";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 602:
                _name = "Gold Coin";
                _description = "High value coin";
                _amount = 1;
                _value = 100;
                _type = ItemType.Money;
                _icon = "Money/GoldCoin";
                _mesh = "Money/GoldCoin";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            #endregion
            #region Craftable 700-799
            case 700:
                _name = "Tusk";
                _description = "Moderate value material";
                _amount = 1;
                _value = 15;
                _type = ItemType.Craftable;
                _icon = "Craftable/Tusk";
                _mesh = "Craftable/Tusk";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 701:
                _name = "Iron";
                _description = "High value material";
                _amount = 1;
                _value = 30;
                _type = ItemType.Craftable;
                _icon = "Craftable/Iron";
                _mesh = "Craftable/Iron";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 702:
                _name = "Wood";
                _description = "Low value material";
                _amount = 1;
                _value = 5;
                _type = ItemType.Craftable;
                _icon = "Craftable/Wood";
                _mesh = "Craftable/Wood";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            #endregion
            #region Quest 800 - 899
            case 800:
                _name = "Heart";
                _description = "Rare part of monster";
                _amount = 1;
                _value = 0;
                _type = ItemType.Quest;
                _icon = "Quest/Heart";
                _mesh = "Quest/Heart";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 801:
                _name = "Wing";
                _description = "Body part from Bat";
                _amount = 1;
                _value = 0;
                _type = ItemType.Quest;
                _icon = "Quest/Wing";
                _mesh = "Quest/Wing";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 802:
                _name = "Tail";
                _description = "Common part from Rodent family";
                _amount = 1;
                _value = 0;
                _type = ItemType.Quest;
                _icon = "Quest/Tail";
                _mesh = "Quest/Tail";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            #endregion
            #region Misc 900-999
            case 900:
                _name = "Emerald";
                _description = "Very Rare Green Rock";
                _amount = 1;
                _value = 100;
                _type = ItemType.Misc;
                _icon = "Misc/Emerald";
                _mesh = "Misc/Emerald";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 901:
                _name = "Amethyst";
                _description = "Very Rare Purple Rock";
                _amount = 1;
                _value = 100;
                _type = ItemType.Misc;
                _icon = "Misc/Amethyst";
                _mesh = "Misc/Amethyst";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 902:
                _name = "Topaz";
                _description = "Very Rare Rock";
                _amount = 1;
                _value = 100;
                _type = ItemType.Misc;
                _icon = "Misc/Topaz";
                _mesh = "Misc/Topaz";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            default: //If there is nothing there set it into the default value ( JUST LIKE ELSE STATEMENT )
                itemID = 0;
                _name = "Acorn";
                _description = "Just Acorn";
                _amount = 1;
                _value = 1;
                _type = ItemType.Ingredient;
                //NOTE Dont forget to change the texture type of the Icon sprite in the inspector into "Editor GUI and Editor GUI"(because we are using hard coding)
                _icon = "Ingredient/Acorn";
                //NOTE Change the name of the icon name accordingly
                _mesh = "Ingredient/Acorn";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
                #endregion
        }
        Item temp = new Item
        {
            ID = itemID,
            Name = _name,
            Description = _description,
            Amount = _amount,
            Value = _value,
            Type = _type,
            Icon = Resources.Load("Icons/" + _icon) as Texture2D,
            ItemMesh = Resources.Load("Mesh/" + _mesh) as GameObject,
            Damage = _damage,
            Armour = _armour,
            Heal = _heal
        };
        return temp;
    }
}

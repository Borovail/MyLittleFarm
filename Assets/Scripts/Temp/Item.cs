using UnityEngine;
using System;

[Serializable]
public class Item
{
    public string Name;
    public float Price;
    public int Amount;
    public Sprite Icon;

    public Item(string name, float price, int amount, Sprite icon)
    {
        Name = name;
        Price = price;
        Amount = amount;
        Icon = icon;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Price: {Price}, Amount: {Amount}";
    }
}


﻿using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void Use()
    {
        //Use the item
        //Something Might happen
        //Debug.Log(name + " used");
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
    
    public void SwapStorage()
    {
        //Storage.instance.Remove(this);
    }
}

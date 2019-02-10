using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Inventory/Consumable")]
public class Consumable : Item
{

    public float modifier = 0;

    public override void Use()
    {
        base.Use();
        Debug.Log("You have consumed " + name);
        RemoveFromInventory();
        /* Add here the poissibillity to switch the item between storage and inventory
        if (Inventory and Storage are active)
        {
            AddToStorage();
            RemoveFromInventory();
        }
        else
        {
            
        }
        */
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : Interactable
{

    public bool isOpen = false;
    public int slotCount = 20;

    public override void Interact()
    {
        base.Interact();
        isOpen = (isOpen) ? CloseStorage() : OpenStorage();
    }

    public bool OpenStorage()
    {
        //Some sort of inventory opens
        //items should be moveable between inventories
        return true;
    }

    public bool CloseStorage()
    {
        //close the inventory
        return false;
    }
}

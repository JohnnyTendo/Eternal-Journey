using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : Interactable
{
    public Transform itemsParent;
    public GameObject inventoryUI2;
    Inventory2 inventory2;
    InventorySlot[] slots;
    
    public bool isOpen = false;
    public int slotCount = 20;
    
    void Start()
    {
        inventory2 = Inventory2.instance;
        inventory2.onItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }
    
    public override void Interact()
    {
        base.Interact();
        inventoryUI2.SetActive(!inventoryUI2.activeSelf);
    }
    
    void UpdateUI()
    {
        Debug.Log("Updating UI2");
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory2.items.Count)
            {
                slots[i].AddItem(inventory2.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}

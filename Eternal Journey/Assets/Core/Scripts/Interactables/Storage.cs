using UnityEngine;

public class Storage : Interactable
{

    public bool isOpen = false;
    public int slotCount = 20;
    public Transform itemsParent;
    public GameObject inventoryUI2;
    Inventory2 inventory2;
    InventorySlot[] slots;

    public override void Interact()
    {
        base.Interact();
        isOpen = (isOpen) ? false : true;
        inventoryUI2.SetActive(!inventoryUI2.activeSelf);
    }

    void Start()
    {
        inventory2 = Inventory2.instance;
        inventory2.onItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
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

using UnityEngine;

public class InventoryUI2 : MonoBehaviour
{

    public Transform itemsParent;
    public GameObject inventoryUI2;
    Inventory2 inventory2;
    InventorySlot[] slots;


    void Start()
    {
        inventory2 = Inventory2.instance;
        inventory2.onItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }


    void Update()
    {
        if (Input.GetButtonDown("Inventory2"))
        {
            //Removed for testing purpose while turning Inventory2 into a storage-system
            //inventoryUI2.SetActive(!inventoryUI2.activeSelf);
        }
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

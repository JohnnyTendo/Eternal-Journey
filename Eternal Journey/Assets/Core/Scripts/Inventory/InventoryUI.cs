using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{

    public Transform itemsParent;
    public GameObject inventoryUI;
    public Text goldCounter;
    public Text woodCounter;
    public Text stoneCounter;
    public Text ironCounter;
    Inventory inventory;
    InventorySlot[] slots;


    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }


    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
        goldCounter.text = inventory.gold.ToString();
        woodCounter.text = inventory.resources[0].ToString();
        stoneCounter.text = inventory.resources[1].ToString();
        ironCounter.text = inventory.resources[2].ToString();
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}

using UnityEngine;

public class ItemPickup : Interactable {

    public Item item;
    public bool isGold;
    public int value;

    public override void Interact() {
        base.Interact();
        PickUp();
    }

    void PickUp() {
        Debug.Log("Picking up " + item.name);
        if (!isGold)
        {
            bool wasPickedUp = Inventory.instance.Add(item);
            if (wasPickedUp)
                Destroy(gameObject);
        }
        if (isGold)
        {
            bool wasPickedUp = Inventory.instance.AddGold(value);
            if (wasPickedUp)
                Destroy(gameObject);
        }
    }
}

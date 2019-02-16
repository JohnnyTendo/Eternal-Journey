using UnityEngine;

public class ItemPickup : Interactable {

    public Item item;
    public bool isGold;
    public int value;
    public Type currentType;
    public ResourceType currentResourceType;
    public enum Type { gold, item, resource }
    public enum ResourceType { Wood, Stone, Iron }

    public override void Interact() {
        base.Interact();
        PickUp();
    }

    void PickUp() {
        int index = (int)currentResourceType;
        string message = string.Format("Picking up {0} witch ResourceType {1}", item.name, index);
        Debug.Log(message);
        if (currentType == Type.item)
        {
            bool wasPickedUp = Inventory.instance.Add(item);
            if (wasPickedUp)
                Destroy(gameObject);
        }
        if (currentType == Type.gold)
        {
            bool wasPickedUp = Inventory.instance.AddGold(value);
            if (wasPickedUp)
                Destroy(gameObject);
        }
        if (currentType == Type.resource)
        {
            bool wasPickedUp = Inventory.instance.AddResources(value, index);
            if (wasPickedUp)
                Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory2 : MonoBehaviour {

    public List<Item> items = new List<Item>();

    public static Inventory2 instance;
    #region singleton
    void Awake() {
        if (instance != null)
        {
            Debug.LogWarning("More then one instance of Inventory2 found!");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 20;

    public bool Add(Item item) {
        if (!item.isDefaultItem) {
            if (items.Count >= space) {
                Debug.Log("Inventory2 full!");
                return false;
            }
            items.Add(item);
            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
        return true;
    }

    public void Remove(Item item) {
        items.Remove(item);
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}

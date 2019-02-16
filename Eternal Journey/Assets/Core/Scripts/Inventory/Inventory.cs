using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public List<Item> items = new List<Item>();
    public int gold = new int();
    public int[] resources = new int[3];
        //resources[0]=wood ; resources[1]=stone ; resources[2]=iron ; 

    public static Inventory instance;
    #region singleton
    void Awake() {
        if (instance != null)
        {
            Debug.LogWarning("More then one instance of Inventory found!");
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
                Debug.Log("Inventory full!");
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

    public bool AddGold(int money)
    {
        gold += money;
        return true;
    }

    public void RemoveGold(int money)
    {
        gold -= money;
    }

    public bool AddResources(int amount, int index)
    {
        resources[index] += amount;
        return true;
        //resources[0]=wood ; resources[1]=stone ; resources[2]=iron ; 
    }

    public void RemoveResources(int amount, int index)
    {
        resources[index] -= amount;
        //resources[0]=wood ; resources[1]=stone ; resources[2]=iron ; 
    }
}

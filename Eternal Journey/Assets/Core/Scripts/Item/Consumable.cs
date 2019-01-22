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
    removeFromInventory();
    Debug.Log("You have consumed " + name);
  }
}

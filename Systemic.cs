using UnityEngine;

public class Systemic : MonoBehaviour {
  public enum entityTag { plants, trees, npcFriendly, npcEnemy, animalFriendly, animalEnemy };
  public enum materialTag { wood, stone, flesh, diverse };
  public entityTag currentEntityTag;
  public materialTag currentMaterialTag;
  
  public void Awake() {
    gameObject.tag = (string)currentEntityTag;
  }
}

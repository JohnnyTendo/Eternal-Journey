using UnityEngine;

public class HarvestResources : Interactable
{
    public GameObject lootDrop;
    public Transform spawnPoint;
    public Vector3 offset;
    public float delay;
    GameObject lootInstance;

    public override void Interact()
    {
        base.Interact();
        Invoke("Destroy", delay);  
    }

    public void Destroy()
    {
        lootInstance = (GameObject)Instantiate(lootDrop, spawnPoint.position + offset, Quaternion.identity);
        Destroy(gameObject);
    }
}

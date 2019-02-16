using UnityEngine;

public class HarvestResources : Interactable
{
    public GameObject lootDrop;
    public Transform spawnPoint;
    public Vector3 offset;
    public float Xrotation;
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
        lootInstance.transform.rotation *= Quaternion.Euler(Xrotation, 0, 0);
        Destroy(gameObject);
    }
}

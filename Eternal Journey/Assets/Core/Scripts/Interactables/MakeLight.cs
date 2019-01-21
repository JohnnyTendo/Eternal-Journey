using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeLight : Interactable
{
    public GameObject flameEffect;
    public GameObject lightSource;
    public Transform spawnPoint;
    public bool isLit;
    public Vector3 offset;

    GameObject flameInstance;
    GameObject lightSourceInstance;

    void Start()
    {
        isLit = false;
    }

    public override void Interact()
    {
        base.Interact();
        if (isLit == false)
        {
            flameInstance = (GameObject)Instantiate(flameEffect, spawnPoint.position + offset, Quaternion.identity);
            lightSourceInstance = (GameObject)Instantiate(lightSource, spawnPoint.position + offset, Quaternion.identity);
            flameInstance.transform.parent = transform;
            lightSourceInstance.transform.parent = transform;
            isLit = true;
        }
        else
        {
            Destroy(flameInstance);
            Destroy(lightSourceInstance);
            isLit = false;
        }
    }
}

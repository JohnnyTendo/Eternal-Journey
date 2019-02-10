using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : Interactable
{
    public float range;
    public bool isOpen;
    public GameObject gateLeft;
    public GameObject gateRight;


    void Start()
    {
        isOpen = false;
    }

    public override void Interact()
    {
        base.Interact();
        if (isOpen == false)
        {
            for (int i = 0; i < range; i++)
            {
                gateLeft.transform.position = new Vector3(0, i, 0);
                gateRight.transform.position = new Vector3(0, -i, 0);
            }
            isOpen = true;
        }
        else
        {
            for (int i = 0; i < range; i++)
            {
                gateLeft.transform.position = new Vector3(0, -i, 0);
                gateRight.transform.position = new Vector3(0, i, 0);
            }
            isOpen = false;
        }
    }
}

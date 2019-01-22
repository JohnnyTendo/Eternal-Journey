using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSide : Interactable
{
    public GameObject currentState;
    public GameObject[] states;
    public Vector3 offset;
    public bool requirements = false;
    public int stateIndex = 0;

    GameObject nextStateInstance;

    void Start()
    {
        currentState = states[0];
    }

    public override void Interact()
    {
        base.Interact();
        if (requirements == true) 
        {
            if (i < states.length)
            {
                Destroy(currentState);
                currentState = (GameObject)Instantiate(states[i], transform.position + offset, Quaternion.identity); 
                currentState.transform.parent = transform;
                i++;
            }
            else
            {
                Debug.Log("Already upgraded to max!");
            }
        } 
        else
        {
        Debug.Log("You are missing the requirements!");
        }
    }
}

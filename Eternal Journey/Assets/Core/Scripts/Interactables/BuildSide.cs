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
    public float Yrotation;

//Testing Vars
    public bool upgrade = true;
//Testing Vars end

    void Awake()
    {
        currentState = (GameObject)Instantiate(states[0], transform.position + offset, Quaternion.identity);
        currentState.transform.rotation *= Quaternion.Euler(0, Yrotation, 0);
        currentState.transform.parent = transform;
    }

    public override void Interact()
    {
        base.Interact();
        if (upgrade == true)
        {
            if (requirements == true)
            {
                if (stateIndex < states.Length -1)
                {
                    Destroy(currentState);
                    stateIndex++;
                    currentState = (GameObject)Instantiate(states[stateIndex], transform.position + offset, Quaternion.identity);
                    currentState.transform.rotation *= Quaternion.Euler(0, Yrotation, 0);
                    currentState.transform.parent = transform;
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
        else
        {
            if (stateIndex > 0)
            {
                Destroy(currentState);
                stateIndex--;
                currentState = (GameObject)Instantiate(states[stateIndex], transform.position + offset, Quaternion.identity);
                currentState.transform.rotation *= Quaternion.Euler(0, Yrotation, 0);
                currentState.transform.parent = transform;
            }
            else
            {
                Debug.Log("Already downgraded to min!");
            }
        }
    }
}

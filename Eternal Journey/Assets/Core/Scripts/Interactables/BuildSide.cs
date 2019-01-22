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

//Testing Vars
    public bool upgrade = true;
//Testing Vars end

    void Start()
    {
        currentState = states[0];
    }

    public override void Interact()
    {
        base.Interact();
        if (upgrade == true)
        {
          Upgrade();
        }
        else
        {
          Downgrade();
        }
    }

    public void Upgrade()
    {
      if (requirements == true)
      {
          if (i < states.length)
          {
            Destroy(currentState);
            i++;
            currentState = (GameObject)Instantiate(states[i], transform.position + offset, Quaternion.identity);
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

    public void Downgrade()
    {
      if (i > 0)
      {
        Destroy(currentState);
        i--;
        currentState = (GameObject)Instantiate(states[i], transform.position + offset, Quaternion.identity);
        currentState.transform.parent = transform;
      }
    }
}

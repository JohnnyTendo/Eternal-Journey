using UnityEngine;

public class BuildSide : Interactable
{
    public GameObject currentState;
    public GameObject[] states;
    public Vector3 offset;
    public int stateIndex = 0;
    public float Yrotation;

//Testing Vars
    public bool requirements = false;
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
        requirements = CheckRequirements();
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
                    hudUI.instance.PostMessage("Already upgraded to max!");
                }
            }
            else
            {
                hudUI.instance.PostMessage("You are missing the requirements!");
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
                hudUI.instance.PostMessage("Already downgraded to min!");
            }
        }
    }

    public bool CheckRequirements()
    {
        int wood = Inventory.instance.resources[0];
        int stone = Inventory.instance.resources[1];
        int iron = Inventory.instance.resources[2];
        int woodRequired = states[stateIndex+1].GetComponent<RequirementsScript>().woodRequired;
        int stoneRequired = states[stateIndex+1].GetComponent<RequirementsScript>().stoneRequired;
        int ironRequired = states[stateIndex+1].GetComponent<RequirementsScript>().ironRequired;
        hudUI.instance.PostMessage("W:" + wood + "|" + woodRequired + " S:" + stone + "|" + stoneRequired + " I:" + iron + "|" + ironRequired);
        if (wood >= woodRequired && stone >= stoneRequired && iron >= ironRequired)
        {
            Inventory.instance.RemoveResources(woodRequired, 0);
            Inventory.instance.RemoveResources(stoneRequired, 1);
            Inventory.instance.RemoveResources(ironRequired, 2);
            return true;
        }
        else
            return false;
    }
}

using UnityEngine;

public class OpenGate : Interactable
{
    private bool isOpen = false;
    public GameObject gate;
    
    public override void Interact()
    {
        base.Interact();
        if (isOpen == false)
        {
            gate.SetActive(isOpen);
            isOpen = true;
        }
        else
        {
            gate.SetActive(isOpen);
            isOpen = false;
        }
    }
}

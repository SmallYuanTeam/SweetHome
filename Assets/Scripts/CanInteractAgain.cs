using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanInteractAgain : MonoBehaviour
{
    public int interactCount = 0;

    public void Interact()
    {
        interactCount++;
    }
}

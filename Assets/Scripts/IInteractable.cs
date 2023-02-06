using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IInteractable : MonoBehaviour
{
  public void Interact()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gunPickup : MonoBehaviour,IInteractable
{
  
    public bool gunActive;
    public Image gunIcon;
    public GameObject gunVisible;
    

    public void Start()
    {
        gunActive = false;
        gunVisible.SetActive(false);
        gunIcon.gameObject.SetActive(false);
        
    }

    public void Interact()
    {
        gunActive = true;
        gunVisible.SetActive(true);
        gunIcon.gameObject.SetActive(true);
        Destroy(this.gameObject);



    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunHit : MonoBehaviour
{
    public Transform firePoint; // The point from which the raycast is fired
    public float range = 100f; // The maximum distance the raycast can travel
    public gunPickup gunCheck;
    public gunStats currentGun;
    public List<gunStats> gunTypes = new List<gunStats>();
    private int index;



    public void typeSwitch()
    {
        if (Input.GetKeyDown("1"))
        {
            index = 0;
            currentGun = gunTypes[index];
        }
        if (Input.GetKeyDown("2"))
        {
            index = 1;
            currentGun = gunTypes[index];
        }
        if (Input.GetKeyDown("3"))
        {
            index = 2;
            currentGun = gunTypes[index];
        }
    }
    // Update is called once per frame
    void Update()
    {


        typeSwitch(); 

        if (gunCheck.gunActive == false)
        {
            return;
        }
        else 
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Cast a ray from the fire point forward
        RaycastHit hit;
        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, range))
        {
            Debug.Log(hit.transform.gameObject.name);
           if(hit.transform.gameObject.GetComponent<enemyScript>())
            {
               
               if (hit.transform.gameObject.GetComponent<enemyScript>().stats.type == currentGun.type)
                {
                    Destroy(hit.transform.gameObject);
                }
            }

            // Here you can add code to damage the target or apply any other effects
        }
    }
}

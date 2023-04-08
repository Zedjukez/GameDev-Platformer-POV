using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerManager : MonoBehaviour
{
    public Image lightActive;
    public Image darkActive;
    public Image shadowActive;

    // Start is called before the first frame update
    void Start()
    {
        
        
        lightActive.gameObject.SetActive(false);
        darkActive.gameObject.SetActive(false);
        shadowActive.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
       

        

        if (Input.GetKeyDown("1"))
        {
            shadowActive.gameObject.SetActive(true);
            lightActive.gameObject.SetActive(false);
            darkActive.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown("2"))
        {
            shadowActive.gameObject.SetActive(false);
            lightActive.gameObject.SetActive(false);
            darkActive.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown("3"))
        {
            shadowActive.gameObject.SetActive(false);
            lightActive.gameObject.SetActive(true);
            darkActive.gameObject.SetActive(false);
        }

    }
}

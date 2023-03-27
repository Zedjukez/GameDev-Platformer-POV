using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformControl : MonoBehaviour,IInteractable
{
    public Vector3 highPlat;
    private Vector3 lowPlat;
    public float objectSpeed;
    public bool goesUp;
    public float objectTime;
    

    bool isScaling = false;

    void Start()
    {
        lowPlat = transform.position;
    }

    IEnumerator returnTime(float timer)
    {
        if (timer == 0)
        {
            yield return null;
        }
        yield return new WaitForSeconds(timer);
        StartCoroutine(moveOverTime(transform, lowPlat, objectSpeed));
        goesUp = !goesUp;
    }

    IEnumerator moveOverTime(Transform objectToScale, Vector3 toPosition, float duration)
    {
        //Make sure there is only one instance of this function running
        if (isScaling)
        {
            yield break; ///exit if this is still running
        }
        isScaling = true;

        float counter = 0;

        //Get the current scale of the object to be moved
        Vector3 startScaleSize = objectToScale.position;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            objectToScale.position = Vector3.Lerp(startScaleSize, toPosition, counter / duration);
            yield return null;
        }
        StartCoroutine(returnTime(objectTime));
        isScaling = false;

    }
    public void Interact()
    {
        if (!goesUp)
        {
            StartCoroutine(moveOverTime(transform, highPlat + transform.position, objectSpeed));
            goesUp = !goesUp;
        }
        else if (goesUp)
        {
            StartCoroutine(moveOverTime(transform, lowPlat, objectSpeed));
            goesUp = !goesUp;
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekObject : MonoBehaviour
{
    private GameObject leftObject;
    private GameObject rightObject;


    private void Start()
    {

    }
    public void ComparisonObject ()
    {
        Destroy(leftObject);
        Destroy(rightObject);      
    }

    public bool GetCheckObjekt(int number, GameObject gameObject)
    {
        if (number == 0) leftObject = gameObject;
        else if (number == 1) rightObject = gameObject;
        if (leftObject != null && rightObject != null)
        {
            if (leftObject.GetComponent<TipeObject>().typeFile == rightObject.GetComponent<TipeObject>().typeFile)
            {
                StartCoroutine(waitTime());
                return true;
            }
            return false;  
        }
        return false;       
    }
    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(0.5f);
        ComparisonObject();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheker : MonoBehaviour
{
    private GameObject _leftObject;
    private GameObject _rightObject;
    private GameObject _tempObject;
    [SerializeField] private Transform _leftTransform, _rightTranform;


    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<TypeObject>().ColliderObj = true;

        if (other.GetComponent<TypeObject>().GrabbingObj)
        {
            _tempObject = other.gameObject;
            
        }

    }

    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<TypeObject>().ColliderObj = false;
        if (_leftObject == other.gameObject)
        {
            _leftObject = null;
            
        }
    }
   

    private bool ChekPosicionTemp(GameObject ChekObj)
    {
        if (_leftObject == ChekObj) return true;
        else return false;
    }

    public void ChekPosicion ()
    {
        if (_leftObject == null && _tempObject !=null)
        {   if (_tempObject.GetComponent<TypeObject>().ColliderObj)
            {
                _leftObject = _tempObject;
                _leftObject.transform.position = _leftTransform.position;
                _leftObject.transform.rotation = _leftTransform.rotation;
                _leftObject.GetComponent<Rigidbody>().isKinematic = true;
                _leftObject.GetComponent<Rigidbody>().freezeRotation = true;
            }
        }

    }

}

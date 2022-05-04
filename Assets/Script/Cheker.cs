using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheker : MonoBehaviour
{


    [SerializeField] private Transform _position;
    private GameObject _Object;
    private ChekObject chekObject;
    [SerializeField] private Raycast raycast;
    [SerializeField] int numberCheker = 0;
    private bool _freePosiciob = true;

    private void Start()
    {
        chekObject = FindObjectOfType<ChekObject>();
    }


    private void OnTriggerEnter(Collider other)
    {

        if (_freePosiciob)
        {
            Debug.Log("2323");
            _Object = other.gameObject;
            raycast.ChekerActive(_position);
            chekObject.GetCheckObjekt(numberCheker, _Object);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (!_freePosiciob)
        {
            _Object = null;
            chekObject.GetCheckObjekt(numberCheker, _Object);
            
        }
    }

}

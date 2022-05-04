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

    private void Update()
    {
        if (_Object == null && !_freePosiciob) _freePosiciob = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_freePosiciob)
        {
            _Object = other.gameObject;
            raycast.ChekerActive(_position);
            _freePosiciob = false;
            chekObject.GetCheckObjekt(numberCheker, _Object);
        }

    }



    public void PushObject()
    {
        Debug.Log("Push");
        _freePosiciob = true;
        if (_Object != null)
        {
            _Object.GetComponent<Rigidbody>().velocity = new Vector3(0, 8, -5);
            _Object = null;
            chekObject.GetCheckObjekt(numberCheker, _Object);
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheker : MonoBehaviour
{


    [SerializeField] private Transform _position, _respawn;
    private GameObject _Object;
    private ChekObject chekObject;
    [SerializeField] private Raycast raycast;
    [SerializeField] int numberCheker = 0;


    private void Start()
    {
        chekObject = FindObjectOfType<ChekObject>();
    }

    private void Update()
    {
    }


    private void OnTriggerStay(Collider other)
    {
        
        if (other == null) Debug.Log(1212); ;
    }




}

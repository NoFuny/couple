using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    [SerializeField] private Transform left, right, top, down;
    private Camera _mainCamera;
    [SerializeField] private float radius;

    void Start()
    {
        _mainCamera = Camera.main;
        top.position = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height-radius, _mainCamera.transform.position.z + 30));
        down.position = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2,  radius, _mainCamera.transform.position.z + 30));
        left.position = _mainCamera.ScreenToWorldPoint(new Vector3(radius, Screen.height/2, _mainCamera.transform.position.z + 30));
        right.position = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width - radius, Screen.height / 2, _mainCamera.transform.position.z + 30));

    }

}

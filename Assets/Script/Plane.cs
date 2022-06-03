using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    [SerializeField] private Transform left, right, top, down;
    [SerializeField] private Transform plane;
    private Camera _mainCamera;
    // [SerializeField] private float radius;

    void Start()
    {
        _mainCamera = Camera.main;
        //top.position = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height - radius, _mainCamera.transform.position.z + 30));
        //down.position = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2, radius, _mainCamera.transform.position.z + 30));
        //left.position = _mainCamera.ScreenToWorldPoint(new Vector3(radius, Screen.height / 2, _mainCamera.transform.position.z + 30));
        //right.position = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width - radius, Screen.height / 2, _mainCamera.transform.position.z + 30));
        Gismosqq();
    }

    private void Gismosqq()
    {
        Vector3 cameraToObject = plane.position - Camera.main.transform.position;
        // отрицание потому что игровые объекты в данном случае находятся ниже камеры по оси y
        float distance = -Vector3.Project(cameraToObject, Camera.main.transform.forward).y;

        // вершины "среза" пирамиды видимости камеры на необходимом расстоянии от камеры
        Vector3 leftBot = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));

        // границы в плоскости XZ, т.к. камера стоит выше остальных объектов
        float x_left = leftBot.x;
        float x_right = rightTop.x;
        float z_top = rightTop.z;
        float z_bot = leftBot.z;

        top.transform.position = rightTop;
        right.transform.position = rightTop;
        down.transform.position = leftBot;
        left.transform.position = leftBot;
    }
}

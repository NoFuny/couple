using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    private Camera _mainCamera;
    private GameObject _enterObject;
    [SerializeField] private Cheker _cheker;
    [SerializeField] int RadiusPlane = 75;
    public float step = 2;
    AudioSource audio;
    public AudioClip clickSound;

    void Start()
    {
        _mainCamera = Camera.main;
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
           // audio.PlayOneShot(clickSound);
            //    Выпускает луч и проверяет объет, если обект доступен для хвататние записывает его в переменную
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "Grabbing")
                {
                    _enterObject = hit.transform.gameObject;
                    _enterObject.GetComponent<TypeObject>().GrabbingObj = true;
                     EnterObject(_enterObject, true);
                }
            }
        }

        if (Input.GetMouseButtonUp(0) && _enterObject != null)
        {
            EnterObject(_enterObject, false);
            _enterObject.GetComponent<TypeObject>().GrabbingObj = false;
            _enterObject = null;
            _cheker.ChekPosicion();
        }
        if (_enterObject != null)
        {
            Vector3 targetPos;
            targetPos = _mainCamera.ScreenToWorldPoint(PixelCamera ());
            _enterObject.transform.transform.position = targetPos;
        }

    }
    
        private Vector3 PixelCamera()
    {

        float _posicionX ,_posicionY;
        if (Input.mousePosition.x > Screen.width - RadiusPlane) _posicionX = Screen.width - RadiusPlane;
        else if (Input.mousePosition.x < RadiusPlane) _posicionX = RadiusPlane;
        else _posicionX = Input.mousePosition.x;

        if (Input.mousePosition.y > Screen.height - RadiusPlane) _posicionY = Screen.height - RadiusPlane;
        else if (Input.mousePosition.y < RadiusPlane) _posicionY = RadiusPlane;
        else _posicionY = Input.mousePosition.y;

        return new Vector3(_posicionX, _posicionY, _mainCamera.transform.position.z + 12);
    }


        public void EnterObject(GameObject gameObject, bool activity)
        {
            //gameObject.GetComponent<Rigidbody>().mass = 0.0001f; // убираем массу, чтобы не сбивать другие объекты
        gameObject.GetComponent<Rigidbody>().useGravity = !activity; // убираем гравитацию
        gameObject.GetComponent<Rigidbody>().isKinematic = activity;
        gameObject.GetComponent<Rigidbody>().freezeRotation = activity; // заморозка вращения


        }

        // функция снимает активность с объекта
        public void ChekerActive(Transform transforPosicion)
        {
            var _tempGameObject = _enterObject;
            EnterObject(_enterObject, false);
            _enterObject = null;
            _tempGameObject.transform.position = transforPosicion.position;
            _tempGameObject.transform.rotation = transforPosicion.rotation;
            _tempGameObject = null;
        }


    } 


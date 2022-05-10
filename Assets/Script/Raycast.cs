using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    private Camera _mainCamera;
    private GameObject _enterObject;
    private Vector3 _startInpunMous, _deltaInputMouse;
    public float step = 2;

    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //    Выпускает луч и проверяет объет, если обект доступен для хвататние записывает его в переменную
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "Grabbing")
                {
                    _enterObject = hit.transform.gameObject;
                    _deltaInputMouse = Input.mousePosition;
                    EnterObject(_enterObject, true);
                }
                else if (hit.transform.gameObject.tag == "Cheker")
                {
                    //hit.transform.gameObject.GetComponent<Cheker>().PushObject();
                }
            }
        }
        if (Input.GetMouseButtonUp(0) && _enterObject != null)
        {
            EnterObject(_enterObject, false);
            _enterObject = null;
        }
        if (_enterObject != null)
        {
            Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _mainCamera.transform.position.y));
            _enterObject.GetComponent<Rigidbody>().MovePosition(new Vector3(mousePosition.x, 3, mousePosition.z));
        }

    }
    
        public void EnterObject(GameObject gameObject, bool activity)
        {
            //gameObject.GetComponent<Rigidbody>().mass = 0.0001f; // убираем массу, чтобы не сбивать другие объекты
            gameObject.GetComponent<Rigidbody>().useGravity = !activity; // убираем гравитацию
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


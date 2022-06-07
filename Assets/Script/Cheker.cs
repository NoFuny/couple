using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheker : MonoBehaviour
{
    private GameObject _leftObject;
    private GameObject _rightObject;
    private GameObject _tempObject;
    [SerializeField] private Transform _leftTransform, _rightTranform;
    [SerializeField] private SceneManagerLvl sceneManager;


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
        if (_leftObject == other.gameObject && _leftObject.GetComponent<TypeObject>().GrabbingObj)
        {
            _leftObject = null;            
        }
    }
   

    private bool ChekPosicionTemp(GameObject ChekObj)
    {
        if (_leftObject == ChekObj) return true;
        else return false;
    }

    // Постановка объекта в поле для сравнения
    public void ChekPosicion ()
    {
        if (_leftObject == null || _leftObject == _tempObject)
        {   if (_tempObject != null && _tempObject.GetComponent<TypeObject>().ColliderObj)
            {
                _leftObject = _tempObject;
                PosicionChek(_leftObject, _leftTransform);
            }
        }
        else
        {
            _rightObject = _tempObject;
            Chek();
        }

    }

    // Функция сравнения объектов
    private void Chek()
    {
        if (_rightObject.GetComponent<TypeObject>().typeObj == _leftObject.GetComponent<TypeObject>().typeObj && _rightObject.GetComponent<TypeObject>().ColliderObj)

        {
            PosicionChek(_rightObject, _rightTranform);
            sceneManager.ChekTrue();
            StartCoroutine(waitTime());
        }
        else if (_rightObject.GetComponent<TypeObject>().ColliderObj)
        {
            sceneManager.SoundClickNo();
            _rightObject.GetComponent<Rigidbody>().AddForce(Random.Range(-200,200),-1000,-1500);
            _rightObject = null;
            
        }
    }

    private void PosicionChek(GameObject gameObj, Transform posicionChek)
    {
        gameObj.transform.position = posicionChek.position;
        gameObj.transform.rotation = posicionChek.rotation;
        gameObj.GetComponent<Rigidbody>().isKinematic = true;
        gameObj.GetComponent<Rigidbody>().freezeRotation = true;
    }
    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(0.5f);
        ComparisonObject();
    }

    //удаление объекто и освобождения под них места.
    private void ComparisonObject()
    {
        Destroy(_leftObject);
        Destroy(_rightObject);
        _leftObject = null;
        _rightObject = null;
        
    }
}

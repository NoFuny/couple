using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSpawn : MonoBehaviour
{
    public GameObject[] arrayGameObj;
    [SerializeField] private Transform pointSpawn;
    [SerializeField] private Button[] lvlButton;
    [SerializeField] AudioClip clickSound;
    AudioSource audio;
    public AudioClip soundMenu;

    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(Spawn());
        int nowLvl = PlayerPrefs.GetInt("SaveLvl");
        audio = FindObjectOfType<AudioSource>();
        audio.Play();
        for (int i = 1; i <= nowLvl; i++)
        {
            lvlButton[i].interactable = true;
        }
        
    }



    IEnumerator Spawn()
    {
        while (true) 
        {
            RandomPoint();
            int posicion = Random.Range(0, arrayGameObj.Length);
            var tempObj = Instantiate(arrayGameObj[posicion]);
            tempObj.transform.position = pointSpawn.position;
            tempObj.transform.rotation = pointSpawn.rotation; 
            yield return new WaitForSeconds(0.2f);
        }
    }
    private void RandomPoint()
    {
        pointSpawn.position = new Vector3(Random.Range(0, 20), 30, Random.Range(0, 20));
        pointSpawn.Rotate(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }

    public void OnClickLvl(int lvl)
    {
        SceneManager.LoadScene(lvl);
    }

}

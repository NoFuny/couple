using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerLvl : MonoBehaviour
{
    [SerializeField] float timer = 0;
    [SerializeField] Text timerText, endText;
    [SerializeField] GameObject endGame;
    [SerializeField] int numberLVL;
    private int _minutes;
    private int _seconds;
    private string _zero;
    [SerializeField] private int _doubleObj;


    private void Start()
    {
        _doubleObj = FindObjectsOfType<TypeObject>().Length/2;
    }

    void Update()
    {
        TimerGame();
    }

    private void TimerGame()
    {
        if (!endGame.activeSelf)
        {
            timer -= Time.deltaTime;
            _seconds = (int)timer % 60;
            _minutes = (int)timer / 60;
            _zero = _seconds < 10 ? "0" : "";
            if (timer > 0) timerText.text = $"{_minutes}:{_zero}{_seconds} ";
            else
            {
                endText.text = "Поражение!";
                EndGameWindow(true);

            }
        }

    }

    private void EndGameWindow(bool viewWindow)
    {
        endGame.SetActive(viewWindow);
    }

    public void onClickAddTime()
    {
        timer += 60;
        EndGameWindow(false);
    }
    public void ChekTrue()
    {
        _doubleObj--;
        if (_doubleObj <2 && FindObjectsOfType<TypeObject>().Length==2)
        {
            
            endText.text = "Победа!";
            EndGameWindow(true);
        }
        Debug.Log(_doubleObj);
    }

    public void onClickRestart()
    {
        SceneManager.LoadScene(numberLVL);

    }
    
    public void onClickMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}

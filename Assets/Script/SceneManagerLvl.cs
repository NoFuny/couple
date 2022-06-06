using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerLvl : MonoBehaviour
{
    [SerializeField] float timer = 0;
    [SerializeField] Text timerText, endText;
    [SerializeField] GameObject endGame, nextGameButton, AddButton;
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
                AddButton.SetActive(true);

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
            SavedLvl();
            nextGameButton.SetActive(true);
        }

    }
    private void SavedLvl()
    {
        if(PlayerPrefs.GetInt("SaveLvl")<= numberLVL)
        { 
            PlayerPrefs.SetInt("SaveLvl", numberLVL);
            PlayerPrefs.Save();
        }
    }

    public void onClickRestart()
    {
        SceneManager.LoadScene(numberLVL);
        onClickPause(false);

    }
    
    public void onClickNextGame()
    {
        SceneManager.LoadScene(numberLVL+1);
        onClickPause(false);
    }
    
    public void onClickMainMenu()
    {
        SceneManager.LoadScene(0);
        onClickPause(false);
    }

    public void onClickPause(bool isPuase)
    {
        if (isPuase) Time.timeScale = 0;
        else Time.timeScale = 1;
    }
}

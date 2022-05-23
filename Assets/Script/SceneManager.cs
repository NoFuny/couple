using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    [SerializeField] float timer = 0;
    [SerializeField] Text timerText;
    [SerializeField] GameObject endGame;
    private int _minutes;
    private int _seconds;
    private string _zero;




    void Update()
    {
        TimerGame();
    }

    private void TimerGame()
    {
        timer -= Time.deltaTime;
        _seconds =(int) timer % 60;
        _minutes = (int) timer / 60;
        _zero = _seconds < 10 ? "0": "";
        if (timer > 0) timerText.text = $"{_minutes}:{_zero}{_seconds} ";
        else if (!endGame.activeSelf) endGame.SetActive(true);

    }
}

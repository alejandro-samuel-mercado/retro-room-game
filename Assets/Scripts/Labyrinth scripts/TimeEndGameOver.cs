using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeEndGameOver : MonoBehaviour, ITimeObserver
{
    private ISceneChangerCommand gameOverCommand;

    void Start()
    {
        gameOverCommand = new ChangeSceneCommand("GameOver");
        var timer = FindObjectOfType<TimeLabyrinth>();
        timer.AddObserver(this);
    }

    public void OnTimeEnded()
    {
        gameOverCommand.Execute();
    }
}

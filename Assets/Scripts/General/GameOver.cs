using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private float finalTime = 0f;
    private float timmer = 10f;
    public TextMeshProUGUI textTimmer;

    void Update()
    {
        timmer -= Time.deltaTime;
        textTimmer.text =  timmer.ToString("F0");
        if (timmer < finalTime)
        {
            SceneManager.LoadScene("salaPrincipal");
        }
    }


}


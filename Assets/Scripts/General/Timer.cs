using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{ private float finalTime = 0f;
    private float timmer = 60f;
    public TextMeshProUGUI textTimmer;
   
    void Update()
    {
        timmer -= Time.deltaTime;
       textTimmer.text = "Tiempo Restante: " + timmer.ToString("F0");
        if(timmer< finalTime)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

  
}
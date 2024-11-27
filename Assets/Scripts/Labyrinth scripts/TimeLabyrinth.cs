using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeLabyrinth : MonoBehaviour
{
    /*Variable que representa el tiempo final, cuando se alcanza este tiempo, se carga la escena de Game Over.*/
    private float finalTime = 0f;
    /*Tiempo inicial que se va reduciendo en cada actualizacion.*/
    [SerializeField] private float timmer = 35f;
    /*Referencia al objeto TextMeshProUGUI para mostrar el tiempo restante.*/
    public TextMeshProUGUI textTimmer;
private List<ITimeObserver> observers = new List<ITimeObserver>();

    /*Reducir el tiempo con el tiempo transcurrido desde el �ltimo frame.
     * Actualizar el texto que muestra el tiempo restante en el objeto TextMeshProUGUI.
     * Verificar si el tiempo ha llegado al valor final.
     * Cargar la escena llamada "GameOver". */
    void Update()
    {
        timmer -= Time.deltaTime;
        textTimmer.text = "Tiempo Restante: " + timmer.ToString("F0");
          if (timmer < finalTime)
        {
            NotifyTimeEnded();
        }
    }

 public void AddObserver(ITimeObserver observer)
    {
        observers.Add(observer);
    }

    private void NotifyTimeEnded()
    {
        foreach (var observer in observers)
        {
            observer.OnTimeEnded();
        }
    }




}

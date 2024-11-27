using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScriptGameManagerSpawer : MonoBehaviour
{
   public static ScriptGameManagerSpawer instance;
    private int puntaje;
   public TextMeshProUGUI textoPuntaje; 

    private void Awake()
    {
         if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

   
    public void SumarPuntos(int puntos)
    {
        puntaje += puntos;
        ActualizarPuntaje();
    }

    public void RestarPuntos(int puntos)
    {
        puntaje -= puntos;
        ActualizarPuntaje();
    }

    private void ActualizarPuntaje()
    {
        if (textoPuntaje != null)
        {
            textoPuntaje.text = "Puntaje: " + puntaje + "/10";
        }
    }
}

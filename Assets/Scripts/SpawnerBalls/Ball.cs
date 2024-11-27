using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{  private float posicionFinal = -15;
    private int valorSuma = 1;
  private ScriptGameManager scoreManager;
    

  void Start()
    {
      // Obtener referencia al GameManager
        scoreManager = ScriptGameManager.instance;
        if (scoreManager == null)
        {
            Debug.LogError("No se encontró ScriptGameManagerSpawer. Asegúrate de que esté en la escena.");
        }
    }


    void Update()
    {
        if (transform.position.y <= posicionFinal)
        {
           
            scoreManager.RestarPuntos();
            BallPool.Instance.ReturnBall(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
       
        if (other.gameObject.CompareTag("Jugador"))
        {
            scoreManager.SumarPuntos(valorSuma);
            BallPool.Instance.ReturnBall(this.gameObject);
        }
       
    }
}

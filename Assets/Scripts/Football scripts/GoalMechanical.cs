using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalMechanical : MonoBehaviour
{
    public GameObject Ball;
    private int valorSuma=1;
    private void OnCollisionEnter(Collision collision)
    {
        //Verifica la colision con el arquero
        if (collision.gameObject.CompareTag("Ball"))
        {
          //Se encarga de que el generador genere una pelota cuando otra colisiona con el arco
            GeneratorBall generator = FindObjectOfType<GeneratorBall>();
            if (generator != null)
            {
                generator.GenerateBall();
            }
            //destruye la pelota
            Destroy(collision.gameObject);
            //suma un punto al puntaje
            ScriptGameManager.instance.SumarPuntos(valorSuma);
        }
    }
}

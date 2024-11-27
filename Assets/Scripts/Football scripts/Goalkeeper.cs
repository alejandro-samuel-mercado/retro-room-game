using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goalkeeper : MonoBehaviour
{
    public GameObject Ball;
    private float changedirectionX = 4f;
   private GoalkeeperState state;
    private IMovementStrategy movementStrategy;

  private void Awake()
    {
        state = new ActiveGoalkeeperState(); // Estado inicial
        movementStrategy = new DefaultMovementStrategy();
    }

    void Update()
    {
     state.Handle(this);
    }
    public void Move()
    {
        movementStrategy.Move(transform, ref changedirectionX);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //verifica la colicion con el arquero
        if (collision.gameObject.CompareTag("Ball"))
        {
            // hace que el generador, al colisionar la pelota, genere otra
            GeneratorBall generator = FindObjectOfType<GeneratorBall>();
            if (generator != null)
            {
                generator.GenerateBall();
            }
            //destruye la pelota al colisionar la pelota
            Destroy(collision.gameObject);
            //resta un punto al colisionar
            ScriptGameManager.instance.RestarPuntos();
        }
    }
}

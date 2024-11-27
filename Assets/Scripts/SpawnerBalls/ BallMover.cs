using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BallMover : MonoBehaviour
{
    private float velocidadY;
    private float posicionFinalY = -15f;

    // Configurar la velocidad de caída de la pelota en el eje Y
    public void Configurar(float velocidadY)
    {
        this.velocidadY = velocidadY;
    }

    void Update()
    {
        // Hacer que la pelota caiga solo en el eje Y
        transform.Translate(0, velocidadY * Time.deltaTime, 0);

        // Si la pelota alcanza la posición final en Y, se devuelve al pool
        if (transform.position.y <= posicionFinalY)
        {
            BallPool.Instance.ReturnBall(gameObject);  // Devolver al pool en vez de rebotar
        }
    }
}

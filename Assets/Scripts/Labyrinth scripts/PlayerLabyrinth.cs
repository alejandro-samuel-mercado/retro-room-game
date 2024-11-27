using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLabyrinth : MonoBehaviour
{
    /*Variable que representa la velocidad a la que se mover� el jugador en el ejeX*/
    [SerializeField] private float velocidadX = -600f;
    /*Variable que representa la velocidad a la que se mover� el jugador en el ejeY*/
    [SerializeField] private float velocidadY = 600f;
    /*Variable que representa la posicion final del jugador*/
    private Rigidbody rb;
    private ILimitChecker limitChecker;
   private ISceneChangerCommand destruirJugadorCommand;

    /*Se llama al inicio del juego. Se obtiene el componente Rigidbody del GameObject */
    void Start()
    {
        rb = GetComponent<Rigidbody>();

 destruirJugadorCommand = new ChangeSceneCommand("GameOver");
    }
    
    /*Obtiene la entrada del eje horizontal con las teclas izquierda y derecha y la almacena en movimientoX.
     * Llama al metodo MoveX() con la velocidad calculada multiplicando velocidad por el valor de entrada horizontal controlando el movimiento lateral del jugador.
      *Obtiene la entrada del eje vertical con las teclas arriba y abajo y la almacena en movimientoY.
     * Llama al metodo MoveY() con la velocidad calculada multiplicando velocidad por el valor de entrada horizontal controlando el movimiento lateral del jugador..*/

    void Update()
    {

          MoverJugador();
    
        if (limitChecker != null && limitChecker.EstaFueraDeLimites(this.transform.position))
        {
            destruirJugadorCommand.Execute();
        }

    }
    /* Este m�todo se encarga de mover el jugador.
  * MoveX Actualiza la velocidad del componente Rigidbody en el eje X. La velocidad en los ejes Y Z permanece sin cambios. 
  * MoveY Actualiza la velocidad del componente Rigidbody en el eje Y. La velocidad en los ejes X Z permanece sin cambios.*/
  private void MoverJugador()
    {
        float movimientoX = Input.GetAxis("Horizontal");
        float movimientoY = Input.GetAxis("Vertical");
  rb.velocity = new Vector3(velocidadX * movimientoX * Time.deltaTime, velocidadY * movimientoY * Time.deltaTime, rb.velocity.z);
    }

   

}

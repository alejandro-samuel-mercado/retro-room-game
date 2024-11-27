using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LabyrinthRaycast : MonoBehaviour{
   /*Variable que representa el rango máximo del rayo.*/
   
   [SerializeField] private float range = 10f;
  private ISceneChangerCommand sceneChangeCommand;
    private bool dirtyFlag = true;

    void Start()
    {
 sceneChangeCommand = new ChangeSceneCommand("YouWin");
    }

    /* RaycastHit hit Estructura que almacena información sobre el rayo lanzado.
     * Lanzar un rayo hacia adelante desde la posicion actual del objeto.
     * El rayo tiene una longitud igual al rango especificado.
     * Verificar si el rayo ha golpeado un objeto (collider).
     * Carga la escena "YouWin" si el rayo golpea un objeto.  .*/
   void Update()
    {
        if (dirtyFlag)
        {
            LanzarRayo();
        }
    }

   private void LanzarRayo()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            if (hit.collider != null)
            {
                sceneChangeCommand.Execute();
                dirtyFlag = false;
            }
        }
    }



    /*Metodo llamado en el editor para dibujar gizmos que ayudan en la visualizacion.
     * Establece el color de los gizmos a amarillo.
     * Dibujar el rayo en el editor, desde la posición del objeto hacia adelante multiplicado por el rango.*/
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, transform.forward * range);
    }
}

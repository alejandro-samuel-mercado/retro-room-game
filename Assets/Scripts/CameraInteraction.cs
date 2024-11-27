using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CameraInteraction : MonoBehaviour
{
    //Hace referencia al transform de la cámara.
    private new Transform camera;
    //Distancia máxima del Raycast.
    [SerializeField]private float distanciaRayo;
    void Start()
    {
        //Encuentra el transform de la cámara.
        camera = transform.Find("Main Camera");
    }

    void Update()
    {
        //Dibuja el Raycast en color rojo.
        Debug.DrawRay(camera.position, camera.forward * distanciaRayo, Color.red);

        RaycastHit hit;
        //Realiza el Raycast.
        if(Physics.Raycast(camera.position, camera.forward, out hit, distanciaRayo)){
            //Obtiene el número de la capa del objeto con el que colisionó el Raycast.
            int layer = hit.collider.gameObject.layer;
            //Verifica si se está colisionando con la capa especificada y si se realizó un click.
            if (layer == LayerMask.NameToLayer("Pachinko") && Input.GetMouseButtonDown(0))
            {
                //Carga la escena especificada.
                SceneManager.LoadScene("Pachinko");
            }
            else if (layer == LayerMask.NameToLayer("Laberinto") && Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Laberinto");
            }
            else if (layer == LayerMask.NameToLayer("Futbol") && Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Futbol");
            }
        }

    }
}

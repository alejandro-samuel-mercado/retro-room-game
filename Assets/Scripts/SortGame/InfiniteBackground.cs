using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBackground : MonoBehaviour
{
    public float scrollSpeed = 0.5f;  // Velocidad de desplazamiento del fondo
    public GameObject[] backgrounds; // Array para almacenar los segmentos del fondo
    
    private float backgroundWidth;   // Ancho del fondo

    private void Start()
    {
        // Asume que todos los segmentos tienen el mismo tamaño
        if (backgrounds.Length > 0)
        {
            backgroundWidth = backgrounds[0].GetComponent<SpriteRenderer>().bounds.size.x;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();

            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying=false;
            #endif
                
                        }
        // Mueve los segmentos del fondo hacia la izquierda
        foreach (GameObject bg in backgrounds)
        {
            bg.transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

            // Verifica si el fondo ha salido de la vista y reposición
            if (bg.transform.position.x <= -backgroundWidth)
            {
                RepositionBackground(bg);
            }
        }
    }

  
    private void RepositionBackground(GameObject bg)
    {
        Vector3 newPosition = new Vector3(backgroundWidth * (backgrounds.Length - 1), bg.transform.position.y, bg.transform.position.z);
        bg.transform.position = newPosition;
    }
}
